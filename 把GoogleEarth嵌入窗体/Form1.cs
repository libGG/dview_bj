using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using EARTHLib;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// 标记GE是否已经启动
        /// </summary>
        private bool _isGeStarted = false;
        private Control _parentControl;
        private IApplicationGE _googleEarth;
        private IntPtr _geHrender;
        private IntPtr _geParentHrender;
        private IntPtr _geMainHandler;

        /// <summary>
        /// 定义GE应用程序类
        /// </summary>
        private ApplicationGEClass _geApp;

        public Form1()
        {
            InitializeComponent();
        }

        private void OpenGoogleEarthToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StartGE();
            SetGEHandlerToControl(mapPanel, _geApp);
            
        }

        /// <summary>
        /// 启动GE
        /// </summary>
        private void StartGE()
        {
            if (_isGeStarted)
            {
                return;
            }

            try
            {
                _geApp = (ApplicationGEClass) Marshal.GetActiveObject("GoogleEarth.Application");

                _isGeStarted = true;
            }
            catch
            {
                _geApp = new ApplicationGEClass();
                ResizeGEControl();

                _isGeStarted = true;
            }
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
            RealseGEHandler();
        }

        public void SetGEHandlerToControl(Control parentControl, IApplicationGE geApplication)
        {
            _parentControl = parentControl;
            _googleEarth = geApplication;
            _googleEarth = new ApplicationGEClass();
            //获取GE的主窗体句柄
            _geMainHandler = (IntPtr)_googleEarth.GetMainHwnd();
            //将GE主窗体的高宽设置为0，隐藏掉GE主窗体
            NativeMethods.SetWindowPos(_geMainHandler, NativeMethods.HWND_BOTTOM, 0, 0, 0, 0, NativeMethods.SWP_NOSIZE + NativeMethods.SWP_HIDEWINDOW);

            //获取GE地图控件句柄
            _geHrender = (IntPtr)_googleEarth.GetRenderHwnd();
            //获取GE地图控件的父窗体句柄
            _geParentHrender = NativeMethods.GetParent(_geHrender);
            //将GE地图控件的父窗体设置为不可见
            //（考虑到GE地图控件可能被其他程序截获，加上这一句以应万全）
            NativeMethods.PostMessage((int)_geParentHrender, NativeMethods.WM_HIDE, 0, 0);

            //设置GE地图控件的父窗体句柄为winform上的控件
            NativeMethods.SetParent(_geHrender, parentControl.Handle);
        }

        public void RealseGEHandler()
        {
            try
            {
                if (_parentControl != null)
                {
                    //将GE地图控件的句柄还原到GE主窗体上去
                    NativeMethods.SetParent(_geHrender, _geParentHrender);
                    //关闭GE主程序
                    NativeMethods.PostMessage(_googleEarth.GetMainHwnd(), NativeMethods.WM_QUIT, 0, 0);
                }
            }
            finally
            {
                //为防本程序的进程不能成功退出而导致GE出现问题，强制杀掉本程序的进程
                Process geProcess = Process.GetCurrentProcess();
                geProcess.Kill();
            }
        }

        public void ResizeGEControl()
        {
            if (_parentControl != null)
            {
                //设置GE地图控件的大小等于父窗体大小
                NativeMethods.MoveWindow(_geHrender, 0, 0, _parentControl.Width, _parentControl.Height, true);
            }
        }

        private void mapPanel_SizeChanged(object sender, EventArgs e)
        {
            ResizeGEControl();
        }

        private void showLayerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var featureCollectionGE = _googleEarth.GetLayersDatabases();

            MessageBox.Show(featureCollectionGE.Count.ToString());

            var enumerator = featureCollectionGE.GetEnumerator();
            while (enumerator.MoveNext())
            {
                var featureGE = (IFeatureGE) enumerator.Current;
                
            }
             
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            RealseGEHandler();
        }

        private void AddkmlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _googleEarth.OpenKmlFile("C:\\abcde.kml", 1);
        }

        private void aaaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ICameraInfoGE a = _googleEarth.GetCamera(0);
            //_googleEarth.
        }
    }
}
