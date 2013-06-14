using System;
using System.Collections.Generic;
using System.Text;
using ESRI.ArcGIS.Controls;

namespace Controls
{
    class clsProfileStruct
    {
         
            private double zVal;
            private double seVal;
            private double mVal;
        public clsProfileStruct()
		{
			//
			// TODO: 在此处添加构造函数逻辑
  
			//
		}
            public double Z
            {
                get
                {
                    return zVal;
                }
                set
                {
                    zVal = value;
                }
            }
            public double M
            {
                get
                {
                    return mVal;
                }
                set
                {
                    mVal = value;
                }
            }
            public double dSewerElev
            {
                get
                {
                    return seVal;
                }
                set
                {
                    seVal = value;
                }
            }
        
    }
}
