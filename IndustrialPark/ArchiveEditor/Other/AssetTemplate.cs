﻿namespace IndustrialPark
{
    public enum AssetTemplate
    {
        Null,
        Paste_Clipboard,
        User_Template,

        // Controllers
        Counter,
        Conditional,
        Dispatcher,
        Fog,
        Group,
        Portal,
        Progress_Script,
        Script,
        Sound_Group,
        Text,
        Timer,
        Cam_Tweak,
        Disco_Floor,
        Duplicatotron_Settings,

        // Placeable
        Camera,
        Marker,
        Box_Trigger,
        Sphere_Trigger,
        Cylinder_Trigger,
        MovePoint,
        MovePoint_Area,
        Pointer,
        Player,
        Boulder,
        Button,
        Destructible_Object,
        Duplicator,
        Electric_Arc_Generator,
        Hangable,
        Villain,
        Pendulum,
        Platform,
        Simple_Object,
        NPC,
        User_Interface,
        User_Interface_Font,
        SFX_OnEvent,
        SFX_OnRadius,
        SDFX,
        Light,

        // Other
        Animation_List,
        DefaultGlowSceneProp,
        Destructible,
        Collision_Table,
        Environment,
        Flythrough,
        Flythrough_Widget,
        Jaw_Data_Table,
        Level_Of_Detail_Table,
        Model_Info,
        One_Liner,
        Pipe_Info_Table,
        Shadow_Table,
        Shrapnel,
        Sound_Info,
        Surface_Mapper,
        Throwable_Table,
        Empty_Sound,
        Empty_Streaming_Sound,
        Empty_BSP,

        // BFBB Pickups and Tikis
        Shiny_Red,
        Shiny_Yellow,
        Shiny_Green,
        Shiny_Blue,
        Shiny_Purple,
        Underwear,
        Spatula,
        Sock,
        Spongeball,
        Golden_Underwear,
        Artwork,
        Steering_Wheel,
        Power_Crystal,
        Smelly_Sundae,
        Wooden_Tiki,
        Floating_Tiki,
        Thunder_Tiki,
        Shhh_Tiki,
        Stone_Tiki,

        // TSSM Pickups and Tikis
        Manliness_Red,
        Manliness_Yellow,
        Manliness_Green,
        Manliness_Blue,
        Manliness_Purple,
        Krabby_Patty,
        Goofy_Goober_Token,
        Treasure_Chest,
        Nitro,
        Wood_Crate,
        Hover_Crate,
        Explode_Crate,
        Shrink_Crate,
        Steel_Crate,

        // BFBB Enemies
        Fodder,
        Hammer,
        TarTar,
        ChompBot,
        GLove,
        Chuck,
        Chuck_Trigger,
        Monsoon,
        Monsoon_Trigger,
        Sleepytime,
        Sleepytime_Moving,
        BombBot,
        Arf,
        Tubelet,
        BzztBot,
        Slick,
        Slick_Trigger,
        Jellyfish_Pink,
        Jellyfish_Blue,
        Duplicatotron,

        // ...but not for user
        ArfDog,
        TubeletSlave,

        // TSSM Enemies
        Jellyfish,
        Jellyfish_Bucket,
        Fogger_GoofyGoober,
        Fogger_Desert,
        Fogger_ThugTug,
        Fogger_Trench,
        Fogger_Junkyard,
        Fogger_Planktopolis,
        Fogger_v1,
        Fogger_v2,
        Fogger_v3,
        Slammer_GoofyGoober,
        Slammer_Desert,
        Slammer_ThugTug,
        Flinger_Desert,
        Flinger_Trench,
        Flinger_Junkyard,
        Spinner_ThugTug,
        Spinner_Junkyard,
        Spinner_Planktopolis,
        Popper_Trench,
        Popper_Planktopolis,
        Minimerv,
        Mervyn,
        Turret_v1,
        Turret_v2,
        Turret_v3,
        Spawner_BB,
        Spawner_DE,
        Spawner_GG,
        Spawner_TR,
        Spawner_JK,
        Spawner_PT,

        // Stage Items
        Button_Red,
        Pressure_Plate,
        Taxi_Stand,
        Texas_Hitch,
        Texas_Hitch_Platform,
        Checkpoint,
        Checkpoint_Invisible,
        Bus_Stop,
        Teleport_Box,
        Throw_Fruit,
        Freezy_Fruit,
        Springboard,
        Hovering_Platform,
        Bungee_Hook,
        Bungee_Drop,

        // TSSM
        Swinger,
        Swinger_Platform,
        CollapsePlatform_Planktopolis,
        CollapsePlatform_Spongeball,
        CollapsePlatform_ThugTug,
        Ring,
        Ring_Control,

        // ...but not for user
        Pressure_Plate_Base,
        Bus_Stop_DYNA,
        Bus_Stop_BusSimp,
        Bus_Stop_Camera,
        Bus_Stop_Lights,
        Bus_Stop_Trigger,
        Throw_Fruit_Base,
        Checkpoint_Timer,
        Checkpoint_Talkbox,
        Checkpoint_SIMP,
        Checkpoint_SIMP_TSSM,
        Checkpoint_Script,
        Bungee_Hook_SIMP,
        Start_Camera,
        LKIT_lights,
        LKIT_JF_SB_lights,
        LKIT_jf01_light_kit,

        // Scooby Pickups
        Scooby_Snack,
        Snack_Box,
        Warp_Gate,
        Snack_Gate,
        Save_Point,
        Clue,
        Key,
        Gum,
        Gum_Pack,
        Soap,
        Soap_Pack,

        Cake,
        Hamburger,
        Ice_Cream,
        Sandwich,
        Turkey,

        Shovel,
        Springs,
        Slippers,
        Lampshade,
        Helmet,
        Knight_Helmet,
        Boots,
        Super_Smash,
        Plungers,
        Super_Sonic_Smash,
        Umbrella,
        Gum_Machine,
        Soap_Bubble,

        // Scooby Enemies
        Caveman,
        Creeper,
        Funland_Robot,
        Gargoyle,
        Geronimo,
        Ghost,
        Ghost_Diver,
        Ghost_of_Captain_Moody,
        Headless_Specter,
        Scarecrow,
        Sea_Creature,
        Space_Kook,
        Tar_Monster,
        Witch,
        Witch_Doctor,
        Wolfman,
        Zombie,

        Bat,
        Crab,
        Flying_Fish,
        Rat,
        Spider,
        Killer_Plant,

        Groundskeeper,
        Holly,

        //Shaggy0,
        //Shaggy1,
        //Shaggy4,
        //Shaggy5,
        //Shaggy8,
        //Fred,
        //Daphne,
        //Velma,

        //Black_Knight,
        //Green_Ghost,
        //Redbeard,
        //Mastermind,
        //Shark,

        // Scooby items
        Gust,
        Volume_Box,
        Volume_Sphere,

        Red_Button,
        Floor_Button,
        Red_Button_Smash,
        Floor_Button_Smash,
        Crate,
        Cauldron,
        Flower,

        // ...but not for user
        Red_Button_Base,
        Floor_Button_Base,
        Red_Button_Smash_Base,
        Floor_Button_Smash_Base,
        Cauldron_Sfx,
        Cauldron_Light,
        Cauldron_Emitter,
        Flower_Dig,

        // Incredibles Pickups
        Health_10,
        Health_25,
        Health_50,
        Power_25,
        Power_50,
        Bonus,

        // Incredibles objects
        Zip_Line,
    }
}
