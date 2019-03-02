using System;

namespace FTN.Common
{

    public enum DMSType : short
	{		
		MASK_TYPE							= unchecked((short)0xFFFF),

        LINE                                = 0x0001,
        DCLINESEG                           = 0x0002,
        ACLINESEG                           = 0x0003,
        SERCOMP                             = 0x0004,
        SUBGEOREG                           = 0x0005,
        PERLENSEQIMP                        = 0x0006,
	}

    [Flags]
	public enum ModelCode : long
	{
		IDOBJ								= 0x1000000000000000,
        IDOBJ_GID                           = 0x1000000000000104,

        PSR									= 0x1100000000000000,

		EQUIPMENT							= 0x1110000000000000,
        EQUIPMENT_EQUIPCONT                 = 0x1110000000000109, // DODAJ U KLASU

		CONDEQ								= 0x1111000000000000,

        SERCOMP                             = 0x1111100000040000,
        SERCOMP_R                           = 0x1111100000040105,
        SERCOMP_R0                          = 0x1111100000040205,
        SERCOMP_X                           = 0x1111100000040305,
        SERCOMP_X0                          = 0x1111100000040405,

        CONDUCTOR                           = 0x1111200000000000,

        DCLINESEG                           = 0x1111210000020000,

        ACLINESEG                           = 0x1111220000030000,
        ACLINESEG_B0CH                      = 0x1111220000030105,
        ACLINESEG_BCH                       = 0x1111220000030205,
        ACLINESEG_G0CH                      = 0x1111220000030305,
        ACLINESEG_GCH                       = 0x1111220000030405,
        ACLINESEG_R                         = 0x1111220000030505,
        ACLINESEG_R0                        = 0x1111220000030605,
        ACLINESEG_X                         = 0x1111220000030705,
        ACLINESEG_X0                        = 0x1111220000030805,

        SUBGEOREG                           = 0x1200000000050000,
        SUBGEOREG_LINES                     = 0x1200000000050119,

        CONNODECONT                         = 0x1120000000000000,

        EQUIPCONT                           = 0x1121000000000000,
        EQUIPCONT_EQUIPMENTS                = 0x1121000000000119,

        LINE                                = 0x1121100000010000,
        LINE_SUBGEOREG                      = 0x1121100000010109,

        PERLENIMP                           = 0x1300000000000000,
        PERLENIMP_ACLINESEG                 = 0x1300000000000119,

        PERLENSEQIMP                        = 0x1310000000060005,
        PERLENSEQIMP_B0CH                   = 0x1310000000060105,
        PERLENSEQIMP_BCH                    = 0x1310000000060205,
        PERLENSEQIMP_G0CH                   = 0x1310000000060305,
        PERLENSEQIMP_GCH                    = 0x1310000000060405,
        PERLENSEQIMP_R                      = 0x1310000000060505,
        PERLENSEQIMP_R0                     = 0x1310000000060605,
        PERLENSEQIMP_X                      = 0x1310000000060705,
        PERLENSEQIMP_X0                     = 0x1310000000060805,
    }

    [Flags]
	public enum ModelCodeMask : long
	{
		MASK_TYPE			 = 0x00000000ffff0000,
		MASK_ATTRIBUTE_INDEX = 0x000000000000ff00,
		MASK_ATTRIBUTE_TYPE	 = 0x00000000000000ff,

		MASK_INHERITANCE_ONLY = unchecked((long)0xffffffff00000000),
		MASK_FIRSTNBL		  = unchecked((long)0xf000000000000000),
		MASK_DELFROMNBL8	  = unchecked((long)0xfffffff000000000),		
	}																		
}


