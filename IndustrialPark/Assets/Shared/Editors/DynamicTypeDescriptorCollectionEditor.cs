using HipHopFile;
using Newtonsoft.Json;
using SharpDX.Direct2D1;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace IndustrialPark
{
    public class DynamicTypeDescriptorCollectionEditor : CollectionEditor
    {
        private Game? _game;
        private bool _isDynamicTypeDescriptor = false;

        public DynamicTypeDescriptorCollectionEditor(Type type) : base(type)
        {
        }

        protected override CollectionForm CreateCollectionForm()
        {
            CollectionForm form = base.CreateCollectionForm();
            form.TopMost = true; // Fix winforms bug https://github.com/dotnet/winforms/issues/6190
            form.Size += new Size(50, 50); // and make it a bigger too :)
            return form;
        }

        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            if (value == null && CollectionType != null)
            {
                try
                {
                    if (CollectionType.IsArray)
                        value = Array.CreateInstance(CollectionType.GetElementType(), 0);
                    else
                        value = Activator.CreateInstance(CollectionType);
                }
                catch (Exception ex)
                {
                    throw new InvalidOperationException($"Cannot create an instance of {CollectionType.FullName}.", ex);
                }
            }


            if (value is Array array)
            {
                if (CollectionType.GetElementType().IsClass && context?.Instance is DynamicTypeDescriptor dtd)
                {
                    _isDynamicTypeDescriptor = true;

                    if (dtd.Component != null)
                    {
                        var gameProp = dtd.Component.GetType().GetProperty("game", BindingFlags.Instance | BindingFlags.Public);
                        _game = (Game)gameProp.GetValue(dtd.Component);
                    }

                    var newValue = new List<DynamicTypeDescriptor>();
                    foreach (var item in array)
                    {
                        DynamicTypeDescriptor dt = new DynamicTypeDescriptor(item.GetType());
                        if (item is GenericAssetDataContainer gadc)
                            gadc.SetDynamicProperties(dt);
                        newValue.Add(dt.FromComponent(item));
                    }

                    var result = ((List<DynamicTypeDescriptor>)base.EditValue(context, provider, newValue)).Select(dt => dt.Component).ToList();

                    Type singleType = CollectionType.GetElementType();
                    if (singleType != null)
                    {
                        Array typedArray = Array.CreateInstance(singleType, result.Count);
                        for (int i = 0; i < result.Count; i++)
                        {
                            //typedArray.SetValue(Convert.ChangeType(result[i], singleType), i);
                            typedArray.SetValue(result[i], i);
                        }
                        return typedArray;
                    }
                }
                else
                {
                    List<object> newValue = new(array.Length);
                    foreach (var item in array)
                        newValue.Add(item);

                    var result = base.EditValue(context, provider, newValue);

                    if (result is IList ilist)
                    {
                        Type singleType = CollectionType.GetElementType();
                        if (singleType != null)
                        {
                            Array typedArray = Array.CreateInstance(singleType, ilist.Count);
                            for (int i = 0; i < ilist.Count; i++)
                            {
                                if (!singleType.IsInstanceOfType(ilist[i]))
                                    throw new InvalidCastException($"item at index {i} is not of expected type {singleType.FullName}");
                                typedArray.SetValue(ilist[i], i);
                            }
                            return typedArray;
                        }
                    }
                }
            }

            return base.EditValue(context, provider, value);
        }

        protected override object CreateInstance(Type itemType)
        {
            Type type = CollectionType.GetElementType();
            ConstructorInfo constructor = type?.GetConstructor([typeof(Game)]);

            object instance;

            if (constructor != null)
                instance = constructor.Invoke(new object[] { _game });
            else
                instance = Activator.CreateInstance(type ?? itemType) ?? throw new InvalidOperationException("Cannot create instance of the specified type.");

            if (!_isDynamicTypeDescriptor)
                return instance;

            DynamicTypeDescriptor dt = new DynamicTypeDescriptor(type);
            if (instance is GenericAssetDataContainer gadc)
                gadc.SetDynamicProperties(dt);
            return dt.FromComponent(instance);
        }

        protected override Type CreateCollectionItemType()
        {
            return CollectionType.GetElementType();
        }
    }
}
