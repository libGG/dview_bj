using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Threading;
using System.Drawing.Drawing2D;
using CCWin.SkinClass;

namespace CCWin.SkinControl
{
    [ToolboxBitmap(typeof(ListBox))]
    public partial class ChatListBox : Control
    {
        /// <summary>
        /// 需要优化项选中项时，背景刷新不及时。增加滚动条上下小三角形。
        /// </summary>
        public ChatListBox()
        {
            InitializeComponent();
            //设置自定义控件Style
            this.SetStyle(ControlStyles.ResizeRedraw, true);//调整大小时重绘
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);// 双缓冲
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);// 禁止擦除背景.
            this.SetStyle(ControlStyles.UserPaint, true);//自行绘制
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.ResizeRedraw = true;
            //初始化值
            this.Size = new Size(150, 250);
            this.iconSizeMode = ChatListItemIcon.Large;
            this.Font = new Font("微软雅黑", 9F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(134)));
            this.ForeColor = Color.Black;
            this.items = new ChatListItemCollection(this);
            chatVScroll = new ChatListVScroll(this);
            this.BackColor = Color.FromArgb(50, 255, 255, 255);
        }
        #region 属性
        private ContextMenuStrip subItemMenu;
        /// <summary>
        /// 当用户右击分组时显示的快捷菜单。
        /// </summary>
        [Category("行为")]
        [Description("当用户右击分组时显示的快捷菜单。")]
        public ContextMenuStrip SubItemMenu
        {
            get { return subItemMenu; }
            set
            {
                if (subItemMenu != value)
                {
                    subItemMenu = value;
                }
            }
        }


        private ContextMenuStrip listsubItemMenu;
        /// <summary>
        /// 当用户右击好友时显示的快捷菜单。
        /// </summary>
        [Category("行为")]
        [Description("当用户右击好友时显示的快捷菜单。")]
        public ContextMenuStrip ListSubItemMenu
        {
            get { return listsubItemMenu; }
            set
            {
                if (listsubItemMenu != value)
                {
                    listsubItemMenu = value;
                }
            }
        }

        private ChatListItemIcon iconSizeMode;
        /// <summary>
        /// 与列表关联的图标模式
        /// </summary>
        [DefaultValue(ChatListItemIcon.Large)]
        [Category("Appearance")]
        [Description("与列表关联的图标模式")]
        public ChatListItemIcon IconSizeMode
        {
            get { return iconSizeMode; }
            set
            {
                if (iconSizeMode == value) return;
                iconSizeMode = value;
                this.Invalidate();
            }
        }

        private ChatListItemCollection items;
        /// <summary>
        /// 获取列表中所有列表项的集合
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Category("Data")]
        [Description("列表框中的项")]
        public ChatListItemCollection Items
        {
            get
            {
                if (items == null)
                    items = new ChatListItemCollection(this);
                return items;
            }
        }

        private ChatListSubItem selectSubItem;
        /// <summary>
        /// 当前选中的子项
        /// </summary>
        [Browsable(false)]
        public ChatListSubItem SelectSubItem
        {
            get { return selectSubItem; }
        }

        /// <summary>
        /// 获取或者设置滚动条背景色
        /// </summary>
        [DefaultValue(typeof(Color), "50, 224, 239, 235"), Category("颜色")]
        [Description("滚动条的背景颜色")]
        public Color ScrollBackColor
        {
            get { return chatVScroll.BackColor; }
            set { chatVScroll.BackColor = value; }
        }
        /// <summary>
        /// 获取或者设置滚动条滑块默认颜色
        /// </summary>
        [DefaultValue(typeof(Color), "100, 110, 111, 112"), Category("颜色")]
        [Description("滚动条滑块默认情况下的颜色")]
        public Color ScrollSliderDefaultColor
        {
            get { return chatVScroll.SliderDefaultColor; }
            set { chatVScroll.SliderDefaultColor = value; }
        }
        /// <summary>
        /// 获取或者设置滚动条点下的颜色
        /// </summary>
        [DefaultValue(typeof(Color), "200, 110, 111, 112"), Category("颜色")]
        [Description("滚动条滑块被点击或者鼠标移动到上面时候的颜色")]
        public Color ScrollSliderDownColor
        {
            get { return chatVScroll.SliderDownColor; }
            set { chatVScroll.SliderDownColor = value; }
        }
        /// <summary>
        /// 获取或者设置滚动条箭头的背景色
        /// </summary>
        [DefaultValue(typeof(Color), "Transparent"), Category("颜色")]
        [Description("滚动条箭头的背景颜色")]
        public Color ScrollArrowBackColor
        {
            get { return chatVScroll.ArrowBackColor; }
            set { chatVScroll.ArrowBackColor = value; }
        }
        /// <summary>
        /// 获取或者设置滚动条的箭头颜色
        /// </summary>
        [DefaultValue(typeof(Color), "200, 148, 150, 151"), Category("颜色")]
        [Description("滚动条箭头的颜色")]
        public Color ScrollArrowColor
        {
            get { return chatVScroll.ArrowColor; }
            set { chatVScroll.ArrowColor = value; }
        }

        private Color arrowColor = Color.FromArgb(101, 103, 103);
        /// <summary>
        /// 获取或者设置列表项箭头的颜色
        /// </summary>
        [DefaultValue(typeof(Color), "101, 103, 103"), Category("颜色")]
        [Description("列表项上面的箭头的颜色")]
        public Color ArrowColor
        {
            get { return arrowColor; }
            set
            {
                if (arrowColor == value) return;
                arrowColor = value;
                this.Invalidate();
            }
        }

        private Color itemColor = Color.Transparent;
        /// <summary>
        /// 获取或者设置列表项背景色
        /// </summary>
        [DefaultValue(typeof(Color), "Transparent"), Category("颜色")]
        [Description("列表项的背景色")]
        public Color ItemColor
        {
            get { return itemColor; }
            set
            {
                if (itemColor == value) return;
                itemColor = value;
            }
        }

        private Color subItemColor = Color.Transparent;
        /// <summary>
        /// 获取或者设置子项的背景色
        /// </summary>
        [DefaultValue(typeof(Color), "Transparent"), Category("颜色")]
        [Description("列表子项的背景色")]
        public Color SubItemColor
        {
            get { return subItemColor; }
            set
            {
                if (subItemColor == value) return;
                subItemColor = value;
            }
        }

        private Color itemMouseOnColor = Color.FromArgb(150, 230, 238, 241);
        /// <summary>
        /// 获取或者设置当鼠标移动到列表项的颜色
        /// </summary>
        [DefaultValue(typeof(Color), "150, 230, 238, 241"), Category("颜色")]
        [Description("当鼠标移动到列表项上面的颜色")]
        public Color ItemMouseOnColor
        {
            get { return itemMouseOnColor; }
            set { itemMouseOnColor = value; }
        }

        private Color subItemMouseOnColor = Color.FromArgb(200, 252, 240, 193);
        /// <summary>
        /// 获取或者设置当鼠标移动到子项的颜色
        /// </summary>
        [DefaultValue(typeof(Color), "200, 252, 240, 193"), Category("颜色")]
        [Description("当鼠标移动到子项上面的颜色")]
        public Color SubItemMouseOnColor
        {
            get { return subItemMouseOnColor; }
            set { subItemMouseOnColor = value; }
        }

        private Color subItemSelectColor = Color.FromArgb(200, 252, 236, 172);
        /// <summary>
        /// 获取或者设置选中的子项的颜色
        /// </summary>
        [DefaultValue(typeof(Color), "200, 252, 236, 172"), Category("颜色")]
        [Description("当列表子项被选中时候的颜色")]
        public Color SubItemSelectColor
        {
            get { return subItemSelectColor; }
            set { subItemSelectColor = value; }
        }

        #endregion

        #region 事件
        public delegate void ChatListEventHandler(object sender, ChatListEventArgs e);
        public delegate void DragListEventHandler(object sender, DragListEventArgs e);

        [Description("用鼠标双击子项时发生")]
        [Category("子项操作")]
        public event ChatListEventHandler DoubleClickSubItem;
        [Description("在鼠标进入子项中的头像时发生")]
        [Category("子项操作")]
        public event ChatListEventHandler MouseEnterHead;
        [Description("在鼠标离开子项中的头像时发生")]
        [Category("子项操作")]
        public event ChatListEventHandler MouseLeaveHead;
        [Description("拖动子项操作完成后发生")]
        [Category("子项操作")]
        public event DragListEventHandler DragSubItemDrop;

        protected virtual void OnDoubleClickSubItem(ChatListEventArgs e)
        {
            if (this.DoubleClickSubItem != null)
                DoubleClickSubItem(this, e);
        }

        protected virtual void OnMouseEnterHead(ChatListEventArgs e)
        {
            if (this.MouseEnterHead != null)
                MouseEnterHead(this, e);
        }

        protected virtual void OnMouseLeaveHead(ChatListEventArgs e)
        {
            if (this.MouseLeaveHead != null)
                MouseLeaveHead(this, e);
        }

        protected virtual void OnDragSubItemDrop(DragListEventArgs e)
        {
            if (this.DragSubItemDrop != null)
                DragSubItemDrop(this, e);
        }
        #endregion

        #region 变量
        private Point m_ptMousePos;             //鼠标的位置
        public ChatListVScroll chatVScroll;    //滚动条
        private ChatListItem m_mouseOnItem;
        private bool m_bOnMouseEnterHeaded;     //确定用户绑定事件是否被触发
        private ChatListSubItem m_mouseOnSubItem;
        #endregion

        #region 按下并释放按钮时(OnMouseUp)
        protected override void OnMouseUp(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                chatVScroll.IsMouseDown = false;
            }
            //结束标记
            MouseDowns = false;
            if (e.Button == MouseButtons.Left)
            {
                //判断是否在一个子项上点击
                for (int i = 0, Len = items.Count; i < Len; i++)
                {      //然后判断鼠标是否移动到某一列表项或者子项
                    if (items[i].Bounds.Contains(m_ptMousePos))
                    {
                        if (!items[i].IsOpen && MouseMoveItems)
                        {
                            if (m_mouseOnItem != MouseDowmSubItems.OwnerListItem)
                            {
                                //使用深拷贝克隆一个拖动前的好友
                                ChatListSubItem chatQSubItem = MouseDowmSubItems.Clone();
                                //删除原先位置的好友
                                MouseDowmSubItems.OwnerListItem.SubItems.Remove(MouseDowmSubItems);
                                //展开拖动前的好友列表
                                MouseDowmSubItems.OwnerListItem.IsOpen = true;
                                //更改所属分组
                                MouseDowmSubItems.OwnerListItem = m_mouseOnItem;
                                //将好友移至新分组
                                m_mouseOnItem.SubItems.AddAccordingToStatus(MouseDowmSubItems);
                                //展开拖动后的好友列表
                                m_mouseOnItem.IsOpen = true;
                                //引发拖动事件
                                OnDragSubItemDrop(new DragListEventArgs(chatQSubItem, MouseDowmSubItems));
                            }
                        }
                    }
                    else
                    {
                        if (MouseDowmSubItems != null)
                        {
                            MouseDowmSubItems.OwnerListItem.IsOpen = true;
                        }
                    }
                }
            }
            MouseMoveItems = false;
            MouseDowmSubItems = null;
            base.OnMouseUp(e);
        }
        #endregion

        #region 鼠标按下时(OnMouseDown)
        bool MouseDowns = false;
        ChatListSubItem MouseDowmSubItems;
        int CursorY;
        protected override void OnMouseDown(MouseEventArgs e)
        {
            this.Focus();
            
            m_ptMousePos = e.Location;

            //如果左键在滚动条滑块上点击
            if (chatVScroll.SliderBounds.Contains(m_ptMousePos))
            {
                if (e.Button == MouseButtons.Left)
                {
                    chatVScroll.IsMouseDown = true;
                    chatVScroll.MouseDownY = e.Y;
                }
            }
            else
            {
                //如果在列表上点击 展开或者关闭 在子项上面点击则选中
                foreach (ChatListItem item in items)
                {
                    if (item.Bounds.Contains(m_ptMousePos))
                    {
                        if (item.IsOpen)
                        {
                            foreach (ChatListSubItem subItem in item.SubItems)
                            {
                                if (subItem.Bounds.Contains(m_ptMousePos))
                                {
                                    selectSubItem = subItem;
                                    this.Invalidate();
                                    if (e.Button == MouseButtons.Left)
                                    {
                                        CursorY = Cursor.Position.Y;
                                        MouseDowns = true;
                                        //保存并设置选中Item
                                        MouseDowmSubItems = subItem;
                                    }
                                    else
                                    {
                                        if (ListSubItemMenu == null) return;
                                        ListSubItemMenu.Show(this, m_ptMousePos.X, m_ptMousePos.Y);
                                    }
                                    return;
                                }
                            }
                            if (new Rectangle(0, item.Bounds.Top, this.Width, 20).Contains(m_ptMousePos))
                            {
                                selectSubItem = null;
                                this.Invalidate();
                                if (e.Button == MouseButtons.Left)
                                {
                                    item.IsOpen = !item.IsOpen;
                                }
                                else
                                {
                                    if (SubItemMenu == null) return;
                                    SubItemMenu.Show(this, m_ptMousePos.X, m_ptMousePos.Y);
                                }
                                return;
                            }
                        }
                        else
                        {
                            selectSubItem = null;
                            this.Invalidate();
                            if (e.Button == MouseButtons.Left)
                            {
                                item.IsOpen = !item.IsOpen;
                            }
                            else
                            {
                                if (SubItemMenu == null) return;
                                SubItemMenu.Show(this, m_ptMousePos.X, m_ptMousePos.Y);
                            }
                            return;
                        }
                    }
                }
            }
            base.OnMouseDown(e);
        }
        #endregion

        #region 鼠标滚轮滑动时(OnMouseWheel)
        protected override void OnMouseWheel(MouseEventArgs e)
        {
            if (e.Delta > 0) chatVScroll.Value -= 50;
            if (e.Delta < 0) chatVScroll.Value += 50;
            base.OnMouseWheel(e);
        }
        #endregion

        #region 重绘(OnPaint)
        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.HighQuality; //高质量
            g.PixelOffsetMode = PixelOffsetMode.HighQuality; //高像素偏移质量
            g.TranslateTransform(0, -chatVScroll.Value);        //根据滚动条的值设置坐标偏移
            int SubItemWidth = chatVScroll.ShouldBeDraw ? this.Width - 9 : this.Width;
            Rectangle rectItem = new Rectangle(0, 1, SubItemWidth, 25);                       //列表项区域
            Rectangle rectSubItem = new Rectangle(0, 26, SubItemWidth, (int)iconSizeMode);    //子项区域
            SolidBrush sb = new SolidBrush(this.itemColor);
            try
            {
                for (int i = 0, lenItem = items.Count; i < lenItem; i++)
                {
                    DrawItem(g, items[i], rectItem, sb);        //绘制列表项
                    if (items[i].IsOpen)
                    {
                        //如果列表项展开绘制子项
                        rectSubItem.Y = rectItem.Bottom + 1;
                        for (int j = 0, lenSubItem = items[i].SubItems.Count; j < lenSubItem; j++)
                        {
                            DrawSubItem(g, items[i].SubItems[j], ref rectSubItem, sb);  //绘制子项
                            rectSubItem.Y = rectSubItem.Bottom + 1;             //计算下一个子项的区域
                            rectSubItem.Height = (int)iconSizeMode;
                        }
                        rectItem.Height = rectSubItem.Bottom - rectItem.Top - (int)iconSizeMode - 1;
                    }
                    items[i].Bounds = new Rectangle(rectItem.Location, rectItem.Size);
                    rectItem.Y = rectItem.Bottom + 1;           //计算下一个列表项区域
                    rectItem.Height = 25;
                }
                g.ResetTransform();             //重置坐标系
                chatVScroll.VirtualHeight = rectItem.Bottom - 26;   //绘制完成计算虚拟高度决定是否绘制滚动条
                if (chatVScroll.ShouldBeDraw)   //是否绘制滚动条
                    chatVScroll.ReDrawScroll(g);
            }
            finally { sb.Dispose(); }
            base.OnPaint(e);
        }
        #endregion

        #region 初始化控件时(OnCreateControl)
        protected override void OnCreateControl()
        {
            Thread threadInvalidate = new Thread(new ThreadStart(() =>
            {
                Rectangle rectReDraw = new Rectangle(0, 0, this.Width, this.Height);
                while (true)
                {          //后台检测要闪动的图标然后重绘
                    for (int i = 0, lenI = this.items.Count; i < lenI; i++)
                    {
                        if (items[i].IsOpen)
                        {
                            for (int j = 0, lenJ = items[i].SubItems.Count; j < lenJ; j++)
                            {
                                if (items[i].SubItems[j].IsTwinkle)
                                {
                                    items[i].SubItems[j].IsTwinkleHide = !items[i].SubItems[j].IsTwinkleHide;
                                }
                                rectReDraw.Y = items[i].SubItems[j].Bounds.Y - chatVScroll.Value;
                                rectReDraw.Height = items[i].SubItems[j].Bounds.Height;
                                this.Invalidate(rectReDraw);
                            }
                        }
                        else
                        {
                            rectReDraw.Y = items[i].Bounds.Y - chatVScroll.Value;
                            rectReDraw.Height = items[i].Bounds.Height;
                            if (items[i].TwinkleSubItemNumber > 0)
                            {
                                items[i].IsTwinkleHide = !items[i].IsTwinkleHide;
                            }
                            this.Invalidate(rectReDraw);
                        }
                    }
                    Thread.Sleep(210);
                }
            }));
            threadInvalidate.IsBackground = true;
            threadInvalidate.Start();
            base.OnCreateControl();
        }
        #endregion

        #region 鼠标悬浮在控件区域时(OnMouseMove)
        bool MouseMoveItems = false;
        protected override void OnMouseMove(MouseEventArgs e)
        {
            m_ptMousePos = e.Location;
            if (chatVScroll.IsMouseDown)
            {          //如果滚动条的滑块处于被点击 那么移动
                chatVScroll.MoveSliderFromLocation(e.Y);
                return;
            }
            if (chatVScroll.ShouldBeDraw)
            {
                //如果控件上有滚动条 判断鼠标是否在滚动条区域移动
                if (chatVScroll.Bounds.Contains(m_ptMousePos))
                {
                    ClearItemMouseOn();
                    ClearSubItemMouseOn();
                    //if (chatVScroll.SliderBounds.Contains(m_ptMousePos))
                    //{
                    chatVScroll.IsMouseOnSlider = true;
                    //}
                    //else
                    //{
                    //    chatVScroll.IsMouseOnSlider = false;
                    //}
                    //if (chatVScroll.UpBounds.Contains(m_ptMousePos))
                    chatVScroll.IsMouseOnUp = true;
                    //else
                    //chatVScroll.IsMouseOnUp = false;
                    //if (chatVScroll.DownBounds.Contains(m_ptMousePos))
                    chatVScroll.IsMouseOnDown = true;
                    //else
                    //chatVScroll.IsMouseOnDown = false;
                    return;
                }
                else
                {
                    chatVScroll.ClearAllMouseOn();
                }
            }
            m_ptMousePos.Y += chatVScroll.Value;        //如果不在滚动条范围类 那么根据滚动条当前值计算虚拟的一个坐标
            for (int i = 0, Len = items.Count; i < Len; i++)
            {      //然后判断鼠标是否移动到某一列表项或者子项
                if (items[i].Bounds.Contains(m_ptMousePos))
                {
                    if (items[i].IsOpen)
                    {              //如果展开 判断鼠标是否在某一子项上面
                        for (int j = 0, lenSubItem = items[i].SubItems.Count; j < lenSubItem; j++)
                        {
                            if (items[i].SubItems[j].Bounds.Contains(m_ptMousePos))
                            {
                                if (m_mouseOnSubItem != null)
                                {             //如果当前鼠标下子项不为空
                                    if (items[i].SubItems[j].HeadRect.Contains(m_ptMousePos))
                                    {     //判断鼠标是否在头像内
                                        if (!m_bOnMouseEnterHeaded)
                                        {       //如果没有触发进入事件 那么触发用户绑定的事件
                                            OnMouseEnterHead(new ChatListEventArgs(this.m_mouseOnSubItem, this.selectSubItem));
                                            m_bOnMouseEnterHeaded = true;
                                        }
                                    }
                                    else
                                    {
                                        if (m_bOnMouseEnterHeaded)
                                        {        //如果已经执行过进入事件 那触发用户绑定的离开事件
                                            OnMouseLeaveHead(new ChatListEventArgs(this.m_mouseOnSubItem, this.selectSubItem));
                                            m_bOnMouseEnterHeaded = false;
                                        }
                                    }

                                    #region 点击并移动子项时
                                    //如果点击并移动了子项
                                    if (MouseDowns && Math.Abs(CursorY - Cursor.Position.Y) > 4)
                                    {
                                        //将所有的父节点设置为不展开
                                        for (int z = 0; z < Items.Count; z++)
                                        {
                                            if (Items[z].IsOpen)
                                            {
                                                Items[z].IsOpen = false;
                                            }
                                        }

                                        //开始设置鼠标幻影
                                        m_mouseOnSubItem.OwnerListItem.IsOpen = false;
                                        //开始移动
                                        MouseMoveItems = true;

                                        //获取选中后颜色，再不透明处理
                                        Color color = Color.FromArgb(250, SubItemSelectColor.R, SubItemSelectColor.G, SubItemSelectColor.B);
                                        string strDraw = m_mouseOnSubItem.DisplayName;
                                        Size szFont = TextRenderer.MeasureText(strDraw, this.Font);
                                        int bmpWidth = (45 + szFont.Width + 10);
                                        int bmpHeight = 45;
                                        Bitmap bmp = new Bitmap(bmpWidth * 2, bmpHeight * 2);
                                        Graphics g = Graphics.FromImage(bmp);
                                        g.FillRectangle(new SolidBrush(color), bmpWidth, bmpHeight, bmpWidth, bmpHeight);
                                        g.DrawImage(m_mouseOnSubItem.HeadImage, bmpWidth, bmpHeight, 45, 45);
                                        //判断是否有备注名称
                                        if (szFont.Width > 0)
                                        {
                                            g.DrawString(strDraw, this.Font, Brushes.Black, bmpWidth + bmpHeight + 5, bmpHeight + (bmpHeight - szFont.Height) / 2);
                                        }
                                        else //如果没有备注名称 这直接绘制昵称
                                        {
                                            g.DrawString(m_mouseOnSubItem.NicName, this.Font, Brushes.Black, bmpWidth + bmpHeight + 5, bmpHeight + (bmpHeight - szFont.Height) / 2);
                                        }
                                        Cursor cur = new Cursor(bmp.GetHicon());
                                        Cursor.Current = cur;
                                    }
                                    #endregion
                                }
                                if (items[i].SubItems[j].Equals(m_mouseOnSubItem))
                                {
                                    return;
                                }
                                ClearSubItemMouseOn();
                                ClearItemMouseOn();
                                m_mouseOnSubItem = items[i].SubItems[j];
                                this.Invalidate(new Rectangle(
                                    m_mouseOnSubItem.Bounds.X, m_mouseOnSubItem.Bounds.Y - chatVScroll.Value,
                                    m_mouseOnSubItem.Bounds.Width, m_mouseOnSubItem.Bounds.Height));
                                return;
                            }
                        }
                        ClearSubItemMouseOn();      //循环做完没发现子项 那么判断是否在列表上面
                        if (new Rectangle(0, items[i].Bounds.Top - chatVScroll.Value, this.Width, 20).Contains(e.Location))
                        {
                            if (items[i].Equals(m_mouseOnItem))
                                return;
                            ClearItemMouseOn();
                            m_mouseOnItem = items[i];
                            this.Invalidate(new Rectangle(
                                m_mouseOnItem.Bounds.X, m_mouseOnItem.Bounds.Y - chatVScroll.Value,
                                m_mouseOnItem.Bounds.Width, m_mouseOnItem.Bounds.Height));
                            return;
                        }
                    }
                    else
                    {        //如果列表项没有展开 重绘列表项
                        if (items[i].Equals(m_mouseOnItem))
                            return;
                        ClearItemMouseOn();
                        ClearSubItemMouseOn();
                        m_mouseOnItem = items[i];
                        this.Invalidate(new Rectangle(
                                m_mouseOnItem.Bounds.X, m_mouseOnItem.Bounds.Y - chatVScroll.Value,
                                m_mouseOnItem.Bounds.Width, m_mouseOnItem.Bounds.Height));
                        return;
                    }
                }
            }
            //若循环结束 既不在列表上也不再子项上 清空上面的颜色
            ClearItemMouseOn();
            ClearSubItemMouseOn();
            base.OnMouseMove(e);
        }
        #endregion*

        #region 鼠标离开控件区域时(OnMouseLeave)
        protected override void OnMouseLeave(EventArgs e)
        {
            ClearItemMouseOn();
            ClearSubItemMouseOn();
            chatVScroll.ClearAllMouseOn();
            if (m_bOnMouseEnterHeaded)
            {        //如果已经执行过进入事件 那触发用户绑定的离开事件
                OnMouseLeaveHead(new ChatListEventArgs(this.m_mouseOnSubItem, this.selectSubItem));
                m_bOnMouseEnterHeaded = false;
            }
            base.OnMouseLeave(e);
        }
        #endregion

        #region 在控件区域完成一次点击后(OnClick)
        protected override void OnClick(EventArgs e)
        {
            if (chatVScroll.IsMouseDown) return;    //MouseUp事件触发在Click后 滚动条滑块为点下状态 单击无效
            if (chatVScroll.ShouldBeDraw)
            {         //如果有滚动条 判断是否在滚动条类点击
                if (chatVScroll.Bounds.Contains(m_ptMousePos))
                {        //判断在滚动条那个位置点击
                    if (chatVScroll.UpBounds.Contains(m_ptMousePos))
                        chatVScroll.Value -= 50;
                    else if (chatVScroll.DownBounds.Contains(m_ptMousePos))
                        chatVScroll.Value += 50;
                    else if (!chatVScroll.SliderBounds.Contains(m_ptMousePos))
                        chatVScroll.MoveSliderToLocation(m_ptMousePos.Y);
                    return;
                }
            }

            base.OnClick(e);
        }
        #endregion

        #region 在控件区域完成连续两次点击后(OnDoubleClick)
        protected override void OnDoubleClick(EventArgs e)
        {
            this.OnClick(e);        //双击时 再次触发一下单击事件  不然双击列表项 相当于只点击了一下列表项
            if (chatVScroll.Bounds.Contains(PointToClient(MousePosition))) return;  //如果双击在滚动条上返回
            if (this.selectSubItem != null)     //如果选中项不为空 那么触发用户绑定的双击事件
                OnDoubleClickSubItem(new ChatListEventArgs(this.m_mouseOnSubItem, this.selectSubItem));
            base.OnDoubleClick(e);
        }
        #endregion

        #region 绘制列表项(DrawItem)
        /// <summary>
        /// 绘制列表项
        /// </summary>
        /// <param name="g">绘图表面</param>
        /// <param name="item">要绘制的列表项</param>
        /// <param name="rectItem">该列表项的区域</param>
        /// <param name="sb">画刷</param>
        protected virtual void DrawItem(Graphics g, ChatListItem item, Rectangle rectItem, SolidBrush sb)
        {
            StringFormat sf = new StringFormat();
            sf.LineAlignment = StringAlignment.Center;
            sf.SetTabStops(0.0F, new float[] { 20.0F });
            if (item.Equals(m_mouseOnItem))           //根据列表项现在的状态绘制相应的背景色
                sb.Color = this.itemMouseOnColor;
            else
                sb.Color = this.itemColor;
            g.FillRectangle(sb, rectItem);
            if (item.IsOpen)
            {                      //如果展开的画绘制 展开的三角形
                sb.Color = this.arrowColor;
                g.FillPolygon(sb, new Point[] { 
                        new Point(2, rectItem.Top + 11), 
                        new Point(12, rectItem.Top + 11), 
                        new Point(7, rectItem.Top + 16) });
            }
            else
            {
                sb.Color = this.arrowColor;
                g.FillPolygon(sb, new Point[] { 
                        new Point(5, rectItem.Top + 8), 
                        new Point(5, rectItem.Top + 18), 
                        new Point(10, rectItem.Top + 13) });
                //如果没有展开判断该列表项下面的子项闪动的个数
                if (item.TwinkleSubItemNumber > 0)
                {
                    //如果列表项下面有子项闪动 那么判断闪动状态 是否绘制或者不绘制
                    if (item.IsTwinkleHide)             //该布尔值 在线程中不停 取反赋值
                    {
                        return;
                    }
                }
            }
            string strItem = "\t" + item.Text;
            sb.Color = this.ForeColor;
            sf.Alignment = StringAlignment.Near;
            g.DrawString(strItem, this.Font, sb, rectItem, sf);
            Size Itemsize = TextRenderer.MeasureText(item.Text, this.Font);
            sf.Alignment = StringAlignment.Near;
            g.DrawString("[" + item.SubItems.GetOnLineNumber() + "/" + item.SubItems.Count + "]", this.Font, sb,
                new Rectangle(rectItem.X + Convert.ToInt32(Itemsize.Width) + 25, rectItem.Y, rectItem.Width - 15, rectItem.Height), sf);
        }
        #endregion

        #region 绘制列表子项(DrawSubItem)
        /// <summary>
        /// 绘制列表子项
        /// </summary>
        /// <param name="g">绘图表面</param>
        /// <param name="subItem">要绘制的子项</param>
        /// <param name="rectSubItem">该子项的区域</param>
        /// <param name="sb">画刷</param>
        protected virtual void DrawSubItem(Graphics g, ChatListSubItem subItem, ref Rectangle rectSubItem, SolidBrush sb)
        {
            if (subItem.Equals(selectSubItem))
            {        //判断改子项是否被选中
                rectSubItem.Height = (int)ChatListItemIcon.Large;   //如果选中则绘制成大图标
                sb.Color = this.subItemSelectColor;
                g.FillRectangle(sb, rectSubItem);
                DrawHeadImage(g, subItem, rectSubItem);         //绘制头像
                DrawLargeSubItem(g, subItem, rectSubItem);      //绘制大图标 显示的个人信息
                subItem.Bounds = new Rectangle(rectSubItem.Location, rectSubItem.Size);
                return;
            }
            else if (subItem.Equals(m_mouseOnSubItem))
                sb.Color = this.subItemMouseOnColor;
            else
                sb.Color = this.subItemColor;
            g.FillRectangle(sb, rectSubItem);
            DrawHeadImage(g, subItem, rectSubItem);

            if (iconSizeMode == ChatListItemIcon.Large)         //没有选中则根据 图标模式绘制
                DrawLargeSubItem(g, subItem, rectSubItem);
            else
                DrawSmallSubItem(g, subItem, rectSubItem);

            subItem.Bounds = new Rectangle(rectSubItem.Location, rectSubItem.Size);
        }
        #endregion

        #region 绘制列表子项的头像(DrawHeadImage)
        /// <summary>
        /// 绘制列表子项的头像
        /// </summary>
        /// <param name="g">绘图表面</param>
        /// <param name="subItem">要绘制头像的子项</param>
        /// <param name="rectSubItem">该子项的区域</param>
        protected virtual void DrawHeadImage(Graphics g, ChatListSubItem subItem, Rectangle rectSubItem)
        {
            if (subItem.IsTwinkle)
            {        //判断改头像是否闪动
                if (subItem.IsTwinkleHide)  //同理该值 在线程中 取反赋值
                    return;
            }

            int imageHeight = rectSubItem.Height == 53 ? 40 : 20;      //根据子项的大小计算头像的区域
            subItem.HeadRect = new Rectangle(5, rectSubItem.Top + (rectSubItem.Height - imageHeight) / 2, imageHeight, imageHeight);

            if (subItem.HeadImage == null)                 //如果头像为空 用默认资源给定的头像
            {
                subItem.HeadImage = global::CCWin.Properties.Resources._1_100;
            }
            if (subItem.Status == ChatListSubItem.UserStatus.OffLine)
            {
                g.DrawImage(subItem.GetDarkImage(), subItem.HeadRect);
            }
            else
            {
                g.DrawImage(subItem.HeadImage, subItem.HeadRect);       //如果在线根据在想状态绘制小图标
                if (subItem.Status == ChatListSubItem.UserStatus.QMe)
                    g.DrawImage(global::CCWin.Properties.Resources.QMe, new Rectangle(subItem.HeadRect.Right - 11, subItem.HeadRect.Bottom - 11, 11, 11));
                if (subItem.Status == ChatListSubItem.UserStatus.Away)
                    g.DrawImage(global::CCWin.Properties.Resources.Away, new Rectangle(subItem.HeadRect.Right - 11, subItem.HeadRect.Bottom - 11, 11, 11));
                if (subItem.Status == ChatListSubItem.UserStatus.Busy)
                    g.DrawImage(global::CCWin.Properties.Resources.Busy, new Rectangle(subItem.HeadRect.Right - 11, subItem.HeadRect.Bottom - 11, 11, 11));
                if (subItem.Status == ChatListSubItem.UserStatus.DontDisturb)
                    g.DrawImage(global::CCWin.Properties.Resources.Dont_Disturb, new Rectangle(subItem.HeadRect.Right - 11, subItem.HeadRect.Bottom - 11, 11, 11));
            }

            if (subItem.Equals(selectSubItem))              //根据是否选中头像绘制头像的外边框
            {
                g.DrawImage(Properties.Resources.MainPanel, subItem.HeadRect.X - 3, subItem.HeadRect.Y - 3, 46, 46);
            }
            else
            {
                Pen pen = new Pen(Color.FromArgb(200, 255, 255, 255));
                g.DrawRectangle(pen, subItem.HeadRect);
            }
        }
        #endregion

        #region 绘制大图标模式的个人信息(DrawLargeSubItem)
        /// <summary>
        /// 绘制大图标模式的个人信息
        /// </summary>
        /// <param name="g">绘图表面</param>
        /// <param name="subItem">要绘制信息的子项</param>
        /// <param name="rectSubItem">该子项的区域</param>
        protected virtual void DrawLargeSubItem(Graphics g, ChatListSubItem subItem, Rectangle rectSubItem)
        {
            rectSubItem.Height = (int)ChatListItemIcon.Large;       //重新赋值一个高度
            string strDraw = subItem.DisplayName;
            Size szFont = TextRenderer.MeasureText(strDraw, this.Font);
            Size NickNameFont = TextRenderer.MeasureText(subItem.NicName, this.Font);
            StringFormat Sf = new StringFormat(StringFormatFlags.NoWrap);
            Sf.Trimming = StringTrimming.Word;
            Rectangle Rc = new Rectangle(new Point(rectSubItem.Height, rectSubItem.Top + 8), new Size(this.Width - 9 - rectSubItem.Height, szFont.Height));
            Rectangle NickNameRc = new Rectangle(new Point(rectSubItem.Height + szFont.Width, rectSubItem.Top + 8), new Size(this.Width - 9 - rectSubItem.Height - szFont.Width, szFont.Height));
            //判断是否有备注名称
            if (szFont.Width > 0)
            {
                g.DrawString(strDraw, this.Font, Brushes.Black, Rc, Sf);
                g.DrawString("(" + subItem.NicName + ")",
                    this.Font, Brushes.Gray, NickNameRc, Sf);
            }
            else  //如果没有备注名称 这直接绘制昵称
            {
                Rectangle nkNameRc = new Rectangle(new Point(rectSubItem.Height, rectSubItem.Top + 8), new Size(this.Width - 9 - rectSubItem.Height, szFont.Height));
                g.DrawString(subItem.NicName, this.Font, Brushes.Black, nkNameRc, Sf);
            }
            Size MsgFont = TextRenderer.MeasureText(subItem.PersonalMsg, this.Font);
            Rectangle MsgRc = new Rectangle(new Point(rectSubItem.Height, rectSubItem.Top + 11 + this.Font.Height), new Size(this.Width - rectSubItem.Height, MsgFont.Height));
            //绘制个人签名
            g.DrawString(subItem.PersonalMsg, this.Font, Brushes.Gray, MsgRc, Sf);
        }
        #endregion

        #region 绘制小图标模式的个人信息(DrawSmallSubItem)
        /// <summary>
        /// 绘制小图标模式的个人信息
        /// </summary>
        /// <param name="g">绘图表面</param>
        /// <param name="subItem">要绘制信息的子项</param>
        /// <param name="rectSubItem">该子项的区域</param>
        protected virtual void DrawSmallSubItem(Graphics g, ChatListSubItem subItem, Rectangle rectSubItem)
        {
            rectSubItem.Height = (int)ChatListItemIcon.Small;               //重新赋值一个高度
            StringFormat sf = new StringFormat();
            sf.LineAlignment = StringAlignment.Center;
            sf.FormatFlags = StringFormatFlags.NoWrap;
            string strDraw = subItem.DisplayName;
            if (string.IsNullOrEmpty(strDraw)) strDraw = subItem.NicName;   //如果没有备注绘制昵称
            Size szFont = TextRenderer.MeasureText(strDraw, this.Font);
            sf.SetTabStops(0.0F, new float[] { rectSubItem.Height });
            g.DrawString("\t" + strDraw, this.Font, Brushes.Black, rectSubItem, sf);
            sf.SetTabStops(0.0F, new float[] { rectSubItem.Height + 5 + szFont.Width });
            g.DrawString("\t" + subItem.PersonalMsg, this.Font, Brushes.Gray, rectSubItem, sf);
        }
        #endregion

        #region 清除悬浮分组的悬浮样式(ClearItemMouseOn)
        private void ClearItemMouseOn()
        {
            if (m_mouseOnItem != null)
            {
                int z = 0;
                if (chatVScroll.ShouldBeDraw)
                {
                    z = 9;
                }
                this.Invalidate(new Rectangle(
                    m_mouseOnItem.Bounds.X, m_mouseOnItem.Bounds.Y - chatVScroll.Value,
                    m_mouseOnItem.Bounds.Width + z, m_mouseOnItem.Bounds.Height));
                m_mouseOnItem = null;
            }
        }
        #endregion

        #region 清除悬浮好友的悬浮样式(ClearSubItemMouseOn)
        private void ClearSubItemMouseOn()
        {
            if (m_mouseOnSubItem != null)
            {
                int z = 0;
                if (chatVScroll.ShouldBeDraw)
                {
                    z = 9;
                }
                this.Invalidate(new Rectangle(
                    m_mouseOnSubItem.Bounds.X, m_mouseOnSubItem.Bounds.Y - chatVScroll.Value,
                    m_mouseOnSubItem.Bounds.Width + z, m_mouseOnSubItem.Bounds.Height));
                m_mouseOnSubItem = null;
            }
        }
        #endregion

        #region 根据id返回一组列表子项(GetSubItemsById)
        /// <summary>
        /// 根据id返回一组列表子项
        /// </summary>
        /// <param name="userId">要返回的id</param>
        /// <returns>列表子项的数组</returns>
        public ChatListSubItem[] GetSubItemsById(int userId)
        {
            List<ChatListSubItem> subItems = new List<ChatListSubItem>();
            for (int i = 0, lenI = this.items.Count; i < lenI; i++)
            {
                for (int j = 0, lenJ = items[i].SubItems.Count; j < lenJ; j++)
                {
                    if (userId == items[i].SubItems[j].ID)
                        subItems.Add(items[i].SubItems[j]);
                }
            }
            return subItems.ToArray();
        }
        #endregion

        #region 根据昵称返回一组列表子项(GetSubItemsByNicName)
        /// <summary>
        /// 根据昵称返回一组列表子项
        /// </summary>
        /// <param name="nicName">要返回的昵称</param>
        /// <returns>列表子项的数组</returns>
        public ChatListSubItem[] GetSubItemsByNicName(string nicName)
        {
            List<ChatListSubItem> subItems = new List<ChatListSubItem>();
            for (int i = 0, lenI = this.items.Count; i < lenI; i++)
            {
                for (int j = 0, lenJ = items[i].SubItems.Count; j < lenJ; j++)
                {
                    if (nicName == items[i].SubItems[j].NicName)
                        subItems.Add(items[i].SubItems[j]);
                }
            }
            return subItems.ToArray();
        }
        #endregion

        #region 根据备注名称返回一组列表子项(GetSubItemsByDisplayName)
        /// <summary>
        /// 根据备注名称返回一组列表子项
        /// </summary>
        /// <param name="displayName">要返回的备注名称</param>
        /// <returns>列表子项的数组</returns>
        public ChatListSubItem[] GetSubItemsByDisplayName(string displayName)
        {
            List<ChatListSubItem> subItems = new List<ChatListSubItem>();
            for (int i = 0, lenI = this.items.Count; i < lenI; i++)
            {
                for (int j = 0, lenJ = items[i].SubItems.Count; j < lenJ; j++)
                {
                    if (displayName == items[i].SubItems[j].DisplayName)
                        subItems.Add(items[i].SubItems[j]);
                }
            }
            return subItems.ToArray();
        }
        #endregion

        #region 根据IP返回一组列表子项(GetSubItemsByIp)
        /// <summary>
        /// 根据IP返回一组列表子项
        /// </summary>
        /// <param name="Ip">要返回的Ip</param>
        /// <returns>列表子项的数组</returns>
        public ChatListSubItem[] GetSubItemsByIp(string Ip)
        {
            List<ChatListSubItem> subItems = new List<ChatListSubItem>();
            for (int i = 0, lenI = this.items.Count; i < lenI; i++)
            {
                for (int j = 0, lenJ = items[i].SubItems.Count; j < lenJ; j++)
                {
                    if (Ip == items[i].SubItems[j].IpAddress)
                        subItems.Add(items[i].SubItems[j]);
                }
            }
            return subItems.ToArray();
        }
        #endregion
    }
}
