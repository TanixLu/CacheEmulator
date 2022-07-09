using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CacheEmulator
{
    public partial class MainForm : Form
    {
        MemAccessControler mac;
        Point cacheLocation = new Point(100, 120);
        Size cacheSize = new Size(1400, 600);
        Point memoryLocation = new Point(100, 760);
        Size memorySize = new Size(1500, 150);
        const int memWordNum = 64 * 3, wordNum = 4;
        bool pause;
        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
        int interval;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            setNumComboBox.SelectedIndex = 3;
            lineNumComboBox.SelectedIndex = 1;
            replacementAlgorithmComboBox.SelectedIndex = 0;
            programComboBox.SelectedIndex = 0;
            Cache cache = new Cache(
                cacheLocation, cacheSize,
                int.Parse(setNumComboBox.SelectedItem.ToString()),
                int.Parse(lineNumComboBox.SelectedItem.ToString()), wordNum,
                replacementAlgorithmComboBox.SelectedItem.ToString()
            );
            Memory mem = new Memory(memoryLocation, memorySize, memWordNum, wordNum);
            mac = new MemAccessControler(mem, cache);
        }

        private void MainForm_Paint(object sender, PaintEventArgs e)
        {
            if(mac != null) mac.draw(e.Graphics);
        }

        private void setNumComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (setNumComboBox.SelectedItem != null && lineNumComboBox.SelectedItem != null && replacementAlgorithmComboBox.SelectedItem != null)
            {
                if (mac != null)
                {
                    mac.cacheRef = new Cache(
                        cacheLocation, cacheSize,
                        int.Parse(setNumComboBox.SelectedItem.ToString()),
                        int.Parse(lineNumComboBox.SelectedItem.ToString()), wordNum,
                        replacementAlgorithmComboBox.SelectedItem.ToString()
                    );
                }
                this.Invalidate();
            }
        }

        private void lineNumComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (setNumComboBox.SelectedItem != null && lineNumComboBox.SelectedItem != null && replacementAlgorithmComboBox.SelectedItem != null)
            {
                if (mac != null)
                {
                    mac.cacheRef = new Cache(
                        cacheLocation, cacheSize,
                        int.Parse(setNumComboBox.SelectedItem.ToString()),
                        int.Parse(lineNumComboBox.SelectedItem.ToString()), wordNum,
                        replacementAlgorithmComboBox.SelectedItem.ToString()
                    );
                }
                this.Invalidate();
            }
        }

        private void replacementAlgorithmComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (setNumComboBox.SelectedItem != null && lineNumComboBox.SelectedItem != null && replacementAlgorithmComboBox.SelectedItem != null)
            {
                if (mac != null)
                {
                    mac.cacheRef = new Cache(
                        cacheLocation, cacheSize,
                        int.Parse(setNumComboBox.SelectedItem.ToString()),
                        int.Parse(lineNumComboBox.SelectedItem.ToString()), wordNum,
                        replacementAlgorithmComboBox.SelectedItem.ToString()
                    );
                }
                this.Invalidate();
            }
        }

        /// <summary>
        /// 确认选择的参数, 应用切换到模拟状态, 进行初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void confirmButton_Click(object sender, EventArgs e)
        {
            statisticListView.Visible = false;
            statisticsButton.Text = "统计所有程序";

            setNumComboBox.Enabled = false;
            lineNumComboBox.Enabled = false;
            replacementAlgorithmComboBox.Enabled = false;
            programComboBox.Enabled = false;
            confirmButton.Enabled = false;
            statisticsButton.Enabled = false;

            reselectButton.Enabled = true;
            stepButton.Enabled = true;
            continuousButton.Enabled = true;
            pauseButton.Enabled = true;
            goToEndButton.Enabled = true;
            resetButton.Enabled = true;

            string program = programComboBox.SelectedItem.ToString();
            if (program == "矩阵乘法") mac.genMatMulRecord();
            else if (program == "矩阵乘法改") mac.genCacheFriendlyMatMulRecord();
            else if (program == "冒泡排序") mac.genBubbleSortRecord();
            else if (program == "选择排序") mac.genSelectionSortRecord();
            else if (program == "插入排序") mac.genInsertionSortRecord();
            else if (program == "希尔排序") mac.genShellSortRecord();
            else if (program == "快速排序") mac.genQuicksortRecord();
            this.Invalidate();
        }

        private void reselectButton_Click(object sender, EventArgs e)
        {
            setNumComboBox.Enabled = true;
            lineNumComboBox.Enabled = true;
            replacementAlgorithmComboBox.Enabled = true;
            programComboBox.Enabled = true;
            confirmButton.Enabled = true;
            statisticsButton.Enabled = true;

            reselectButton.Enabled = false;
            stepButton.Enabled = false;
            continuousButton.Enabled = false;
            pauseButton.Enabled = false;
            goToEndButton.Enabled = false;
            resetButton.Enabled = false;

            mac.init();
            this.Invalidate();
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            pause = true;
            mac.reset();
            this.Invalidate();
        }

        private void timerEventProcessor(Object obj, EventArgs eventArgs)
        {
            if (pause || mac.curStep == mac.record.Count)
            {
                timer.Stop();
                return;
            }
            mac.step();
            this.Invalidate();
        }

        private void continuousButton_Click(object sender, EventArgs e)
        {
            pause = false;
            timer.Tick += new EventHandler(timerEventProcessor);
            if (interval < 1)
                timer.Interval = 1;
            else
                timer.Interval = interval;
            timer.Start();
        }

        private void pauseButton_Click(object sender, EventArgs e)
        {
            pause = true;
        }

        private void intervalNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            interval = (int)intervalNumericUpDown.Value;
        }

        private void goToEndButton_Click(object sender, EventArgs e)
        {
            while (mac.curStep < mac.record.Count)
                mac.step();
            this.Invalidate();
        }

        private void statisticsButton_Click(object sender, EventArgs e)
        {
            if (statisticListView.Visible == false)
            {
                statisticListView.Visible = true;
                statisticsButton.Text = "关闭统计";
                statisticListView.Items.Clear();
                foreach (string program in programComboBox.Items)
                {
                    if (program == "矩阵乘法") mac.genMatMulRecord();
                    else if (program == "矩阵乘法改") mac.genCacheFriendlyMatMulRecord();
                    else if (program == "冒泡排序") mac.genBubbleSortRecord();
                    else if (program == "选择排序") mac.genSelectionSortRecord();
                    else if (program == "插入排序") mac.genInsertionSortRecord();
                    else if (program == "希尔排序") mac.genShellSortRecord();
                    else if (program == "快速排序") mac.genQuicksortRecord();
                    while (mac.curStep < mac.record.Count)
                        mac.step();
                    string[] row = {
                        program.ToString(),
                        $"{mac.cacheMissCount}/{mac.curStep}",
                        $"{Decimal.Round((decimal)(mac.curStep == 0? 0: 100.0 * mac.cacheMissCount / mac.curStep), 4)}%",
                        $"{mac.curStep + mac.cacheMissCount * MemAccessControler.cacheMissOverload}",
                        MemAccessControler.cacheMissOverload.ToString()
                    };
                    statisticListView.Items.Add(new ListViewItem(row));
                }
                mac.init();
            }
            else
            {
                statisticListView.Visible = false;
                statisticsButton.Text = "统计所有程序";
            }
        }

        private void helpButton_Click(object sender, EventArgs e)
        {
            string message =
@"
一个cache由多个set组成，每个set由多个line组成，每个line中有特定数量的字，每个set中line的数量叫做组相联度，cache的换入换出是以line为单位的

当cpu访问内存时，会先从cache中寻找，如果cache命中，则访存可在一个周期内完成，否则需要从memory中寻找，memory很慢，一般需要花费额外的50个周期来完成

具体的寻找方式是，内存中编号为x的memLine，对应cache中编号为x % setNum的set
它可以对应set中的任何一个line，因此cache会比对memLine和set中所有line的标签
这一过程是硬件并行的，如果有标签相同则命中，cpu便可直接从该位置读或写数据
如果没命中，则需要将memLine调入cache，这又分为两种情况
若set中有空位，则直接调入其中一个空位
若set中没有空位，则需要选择set中一个line换回内存，这个选择的算法叫替换算法，经典的有FIFO和LRU
FIFO：First In First Out，比方说一个set有四个line，那么换出的顺序可能为0,1,2,3,0,1,2,3,0,1,2,3...
LRU：Least Recently Used，这个算法就聪明一些，每个set会记录一个链表，每访问一个line，它就会被提到表头，那么在表尾的line，就是最不常被用的，下一次有新的line换入的时候就会把它替换掉

本cache采用的是写回法，意思就是会将数据先写到cache里，当line被替换的时候，会再带到内存中
如果一个在cache中的line被写入了数据，那么这个line就是“脏”的，它被替换的时候就需要将最新的数据写回内存；如果被替换的line不脏，就没必要写了

要完成同一种功能，可以有不同的算法，本软件提供了矩阵乘法和排序两类算法
矩阵乘法将0~63视为矩阵A，将64~127视为矩阵B，将128~191视为矩阵C，计算C=AB；矩阵乘法改是cache友好版本的矩阵乘法
排序算法对0~63内存进行排序，提供的几种算法都是就地排序，只需O(1)的额外空间
内存的初始值在打开程序的时候就已确定并不再更改，若需更改请重启程序

选好cache参数及算法后点击确认选择，会生成访存序列，之后可步进或连续运行，连续运行可用每步间隔控制速率
运行过程中memory line为绿色代表其在cache中，cache line为绿色代表非空，为橙色代表脏
运行每一步都会刷新右侧的统计数据，进度：已访存数/总访存数，miss：miss数/已访存数，miss rate：miss的百分比显示，访存周期数：访存数+miss数*overload，overload：固定为50

另提供统计所有程序按钮，给出当前cache参数下所有程序运行完后的统计数据，方便对比
";
            string caption = "说明";
            MessageBox.Show(message, caption);
        }

        private void stepButton_Click(object sender, EventArgs e)
        {
            mac.step();
            this.Invalidate();
        }
    }

    public class Word
    {
        public int value;
        Line lineRef;
        Point location, stringLocation;

        public Word(Point location, Line line)
        {
            this.location = location;
            lineRef = line;
            stringLocation = location;
            stringLocation.X += 2;
            stringLocation.Y += 10;
        }

        public void draw()
        {
            Cache.graphics.DrawRectangle(Pens.Black, new Rectangle(location, Cache.wordSize));
            if (lineRef.valid)
            {
                Brush brush;
                if (lineRef.dirty)
                    brush = Brushes.Orange;
                else
                    brush = Brushes.Green;
                Cache.graphics.FillRectangle(brush, new Rectangle(location, Cache.wordSize));
                Cache.graphics.DrawString($"{value}", new Font("Arial", Cache.fontSize), Brushes.Black, stringLocation);
            }
        }
    }

    public class Line
    {
        int index;
        Point location, stringLocation;
        public Word[] words;
        public bool valid, dirty;
        public int memLine;

        public Line(int index, Point location)
        {
            this.index = index;
            this.location = location;
            stringLocation = location;
            stringLocation.X -= 35;
            stringLocation.Y += Cache.fontSize * 2;
            words = new Word[Cache.wordNum];

            Size offset = new Size((int)(Cache.lineSize.Width / Cache.wordNum * Cache.margin), (int)(Cache.lineSize.Height * Cache.margin));
            for (int i = 0; i < Cache.wordNum; i++)
            {
                words[i] = new Word(location + offset, this);
                offset.Width += Cache.lineSize.Width / Cache.wordNum;
            }
        }

        public void draw()
        {
            Cache.graphics.DrawRectangle(Pens.Black, new Rectangle(location, Cache.lineSize));
            Cache.graphics.DrawString($"line{index}", new Font("Arial", Cache.fontSize), Brushes.Black, stringLocation);
            foreach (Word word in words)
                word.draw();
        }

        public void init()
        {
            valid = false;
        }
    }

    public class Set
    {
        int index;
        Point location, stringLocation;
        public Line[] lines;
        int fifoNextReplace;
        LinkedList<int> lruLinkedList;
        public delegate int replaceFunc();
        public delegate void updateFunc(int lineIndex);
        public replaceFunc getReplacedLine;
        public updateFunc updateWhenHit;

        public Set(int index, Point location)
        {
            this.index = index;
            this.location = location;
            stringLocation = location;
            stringLocation.Y -= Cache.fontSize * 2;
            lines = new Line[Cache.lineNum];

            Size offset = new Size((int)(Cache.setSize.Width * Cache.margin * 1.8),
                (int)(Cache.setSize.Height / Cache.lineRowNum * Cache.margin));
            for (int i = 0; i < Cache.lineNum; i++)
            {
                lines[i] = new Line(i, location + offset);
                offset.Height += Cache.setSize.Height / Cache.lineRowNum;
            }
        }

        public void draw()
        {
            Cache.graphics.DrawRectangle(Pens.Black, new Rectangle(location, Cache.setSize));
            Cache.graphics.DrawString($"set{index}", new Font("Arial", Cache.fontSize), Brushes.Black, stringLocation);
            foreach (Line line in lines)
                line.draw();
        }

        public void init(string replacementAlgorithm)
        {
            if (replacementAlgorithm == "FIFO")
            {
                fifoNextReplace = 0;
                getReplacedLine = fifoGetReplacedLine;
                updateWhenHit = fifoUpdateWhenHit;
            }
            else
            {
                lruLinkedList = new LinkedList<int>();
                for (int i = Cache.lineNum - 1; i >= 0; i--)
                    lruLinkedList.AddLast(i);
                getReplacedLine = lruGetReplacedLine;
                updateWhenHit = lruUpdateWhenHit;
            }

            foreach (Line line in lines)
                line.init();
        }

        int fifoGetReplacedLine()
        {
            int temp = fifoNextReplace;
            fifoNextReplace = (temp + 1) % Cache.lineNum;
            return temp;
        }

        void fifoUpdateWhenHit(int lineIndex)
        {
            return;
        }

        int lruGetReplacedLine()
        {
            var temp = lruLinkedList.Last;
            lruLinkedList.RemoveLast();
            lruLinkedList.AddFirst(temp);
            return temp.Value;
        }

        void lruUpdateWhenHit(int lineIndex)
        {
            lruLinkedList.Remove(lineIndex);
            lruLinkedList.AddFirst(lineIndex);
        }
    }

    public class Cache
    {
        Point location, stringLocation;
        Size size;
        string replacementAlgorithm;
        public Set[] sets;
        public static int setNum, lineNum, wordNum;
        public static Size setSize, lineSize, wordSize;
        public static Graphics graphics;
        public const int setRowNum = 2, setColNum = 4, lineRowNum = 4;
        public const float margin = 0.1f;
        public const int fontSize = 8;

        public Cache(Point location, Size size, int setNum, int lineNum, int wordNum, string replacementAlgorithm)
        {
            (this.location, this.size, Cache.setNum, Cache.lineNum, Cache.wordNum, this.replacementAlgorithm)
                = (location, size, setNum, lineNum, wordNum, replacementAlgorithm);
            stringLocation = location;
            stringLocation.Y -= fontSize * 2;
            sets = new Set[setNum];

            // 计算set, line, word的size
            const float factor = 1 - 2 * margin;

            setSize = new Size();
            setSize.Width = (int)(size.Width / setColNum * factor);
            setSize.Height = (int)(size.Height / setRowNum * factor);

            lineSize = new Size();
            lineSize.Width = (int)(setSize.Width * factor);
            lineSize.Height = (int)(setSize.Height / lineRowNum * factor);

            wordSize = new Size();
            wordSize.Width = (int)(lineSize.Width / wordNum * factor);
            wordSize.Height = (int)(lineSize.Height * factor);

            // 计算各set, line, word的location
            Size offset = new Size((int)(size.Width / setColNum * margin), (int)(size.Height / setRowNum * margin));
            for(int i = 0; i < setNum; i++)
            {
                if (i % 4 == 0)  // set换行
                {
                    offset.Width = (int)(size.Width / setColNum * margin);
                    offset.Height = (int)(size.Height / setRowNum * margin) + size.Height / setRowNum * i / 4;
                }
                sets[i] = new Set(i, location + offset);
                offset.Width += size.Width / setColNum;
            }
        }

        public void draw(Graphics graphics)
        {
            Cache.graphics = graphics;
            graphics.DrawRectangle(Pens.Black, new Rectangle(location, size));
            graphics.DrawString("cache", new Font("Arial", fontSize), Brushes.Black, stringLocation);
            foreach (Set set in sets)
                set.draw();
            Cache.graphics = null;
        }

        public void init()
        {
            foreach (Set set in sets)
                set.init(replacementAlgorithm);
        }
    }

    public class Memory
    {
        Point[] wordLocations, labelLocations;
        string[] labels;
        public int[] wordValues;
        public bool[] inCache;
        Size wordSize;
        const int wordPerRow = 64;
        const float lineMargin = 1.0f;
        const int fontSize = 8;

        public Memory(Point memoryLocation, Size memorySize, int memWordNum, int wordNum)
        {
            int linePerRow = wordPerRow / wordNum;
            int rowNum = memWordNum / wordPerRow;

            wordSize = memorySize;
            wordSize.Width /= wordPerRow + linePerRow - 1;
            wordSize.Height = (int)(wordSize.Height / (rowNum + (rowNum - 1) * lineMargin));

            wordLocations = new Point[memWordNum];
            labelLocations = new Point[2 * rowNum + 1];
            labels = new string[2 * rowNum + 1];
            wordValues = new int[memWordNum];
            inCache = new bool[memWordNum];

            // 计算word的location
            Size offset = new Size(0, 0);
            for (int i = 0; i < memWordNum; i++)
            {
                if (i != 0 && i % 4 == 0 && i % wordPerRow != 0) offset.Width += wordSize.Width;
                if (i != 0 && i % wordPerRow == 0)
                {
                    offset.Width = 0;
                    offset.Height += (int)((1 + lineMargin) * wordSize.Height);
                }
                wordLocations[i] = memoryLocation + offset;
                offset.Width += wordSize.Width;
            }

            // 计算label及其location
            offset.Width = 0;
            offset.Height = wordSize.Height;
            for (int i = 0; i < rowNum * 2; i++)
            {
                if (i != 0 && i % 2 == 0)
                {
                    offset.Width = 0;
                    offset.Height += (int)((1 + lineMargin) * wordSize.Height);
                }
                labelLocations[i] = memoryLocation + offset;
                offset.Width += wordSize.Width * (wordPerRow + linePerRow - 2);
                if (i % 2 == 0)
                    labels[i] = (i / 2 * wordPerRow).ToString();
                else
                    labels[i] = ((i + 1) / 2 * wordPerRow - 1).ToString();
            }
            offset.Width = 0;
            offset.Height = -3 * fontSize;
            labelLocations[rowNum * 2] = memoryLocation + offset;
            labels[rowNum * 2] = "memory";
        }

        public void draw(Graphics graphics)
        {
            for (int i = 0; i < wordLocations.Length; i++)
            {
                if (inCache[i])
                    graphics.FillRectangle(Brushes.Green, new Rectangle(wordLocations[i], wordSize));
                graphics.DrawRectangle(Pens.Black, new Rectangle(wordLocations[i], wordSize));
            }
            for (int i = 0; i < labels.Length; i++)
                graphics.DrawString(labels[i], new Font("Arial", fontSize), Brushes.Black, labelLocations[i]);
        }

        public void init(int[] originA)
        {
            for (int i = 0; i < originA.Length; i++)
            {
                wordValues[i] = originA[i];
                inCache[i] = false;
            }
        }
    }

    public struct Access{
        public int index;
        public int? writeValue;

        public Access(int index, int? writeValue)
        {
            (this.index, this.writeValue) = (index, writeValue);
        }
    };

    public class MemAccessControler
    {
        int[] A;
        int[] originA;
        public List<Access> record;
        public int curStep;
        public int cacheMissCount;
        public const int cacheMissOverload = 50;
        Memory memRef;
        public Cache cacheRef;
        Point progressLocation = new Point(1555, 150);
        const int fontSize = 8;

        public MemAccessControler(Memory mem, Cache cache)
        {
            memRef = mem;
            cacheRef = cache;
            A = new int[mem.wordValues.Length];
            originA = new int[mem.wordValues.Length];
            record = new List<Access>();
            Random rnd = new Random();
            for (int i = 0; i < A.Length; i++)
                originA[i] = rnd.Next(-99, 100);
        }

        public int read(int index)
        {
            record.Add(new Access(index, null));
            return A[index];
        }

        public void write(int index, int writeValue)
        {
            record.Add(new Access(index, writeValue));
            A[index] = writeValue;
        }

        public void init()
        {
            // 重置数组A为originA
            for (int i = 0; i < A.Length; i++)
                A[i] = originA[i];

            // 清空record
            record.Clear();

            // curStep和cacheMissNum置0
            curStep = 0;
            cacheMissCount = 0;

            // mem初始化
            memRef.init(originA);

            // cache初始化
            cacheRef.init();
        }

        public void reset()
        {
            curStep = 0;
            cacheMissCount = 0;
            memRef.init(originA);
            cacheRef.init();
        }

        public void genMatMulRecord()
        {
            init();

            // 获取矩阵边长
            int n = 1;
            while (n * n * 3 <= A.Length) n++;
            n--;

            // 运行矩阵乘法并记录访存顺序
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    // C[i][j] = 0
                    write(n * n * 2 + i * n + j, 0);
                    for (int k = 0; k < n; k++)
                    {
                        // C[i][j] += A[i][k] * B[k][j]
                        int a = read(i * n + k);
                        int b = read(n * n + k * n + j);
                        int c = read(n * n * 2 + i * n + j);
                        write(n * n * 2 + i * n + j, c + a * b);
                    }
                }
            }
        }

        public void genCacheFriendlyMatMulRecord()
        {
            init();

            // 获取矩阵边长
            int n = 1;
            while (n * n * 3 <= A.Length) n++;
            n--;

            // C先清0
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    write(n * n * 2 + i * n + j, 0);

            // cache友好型矩阵乘法
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    int Aij = read(i * n + j);
                    for (int k = 0; k < n; k++)
                    {
                        int Bjk = read(n * n + j * n + k);
                        int Cik = read(n * n * 2 + i * n + k);
                        Cik += Aij * Bjk;
                        write(n * n * 2 + i * n + k, Cik);
                    }
                }
            }
        }

        public void genBubbleSortRecord()
        {
            init();

            // 获取排序长度
            int n = A.Length / 3;

            for (int i = 0; i < n; i++)
            {
                bool swapped = false;
                for (int j = 0; j < n - 1 - i; j++)
                {
                    int Aj = read(j);
                    int Aj1 = read(j + 1);
                    if (Aj > Aj1)
                    {
                        write(j + 1, Aj);
                        write(j, Aj1);
                        swapped = true;
                    }
                }
                if (!swapped) return;
            }
        }

        public void genSelectionSortRecord()
        {
            init();

            // 获取排序长度
            int n = A.Length / 3;

            for (int i = 0; i < n - 1; i++)
            {
                int minIndex = i;
                int iValue, minValue;
                iValue = minValue = read(i);
                for (int j = i + 1; j < n; j++)
                {
                    int Aj = read(j);
                    if (Aj < minValue)
                    {
                        minIndex = j;
                        minValue = Aj;
                    }
                }
                if (minValue < iValue)
                {
                    write(i, minValue);
                    write(minIndex, iValue);
                }
            }
        }

        public void genInsertionSortRecord()
        {
            init();

            // 获取排序长度
            int n = A.Length / 3;

            for (int i = 1; i < n; i++)
            {
                int Ai = read(i);
                for (int j = i; j > 0; j--)
                {
                    int Aj1 = read(j - 1);
                    if (Ai < Aj1)
                        write(j, Aj1);
                    else
                    {
                        if (j != i) write(j - 1, Ai);
                        break;
                    }
                }
            }
        }

        public void genShellSortRecord()
        {
            init();

            // 获取排序长度
            int n = A.Length / 3;

            int gap = 1;
            while (gap < n)
                gap = gap * 3 + 1;

            while (gap > 0)
            {
                for (int i = gap; i < n; i++)
                {
                    int Ai = read(i);
                    int j = i - gap;
                    while (j >= 0)
                    {
                        int Aj = read(j);
                        if (Aj <= Ai) break;
                        write(j + gap, Aj);
                        j -= gap;
                    }
                    if (j + gap != i) write(j + gap, Ai);
                }
                gap /= 3;
            }
        }

        public void genQuicksortRecord()
        {
            init();

            // 获取排序长度
            int n = A.Length / 3;

            // 运行快速排序
            quicksort(0, n - 1);
        }

        public void quicksort(int p, int r)
        {
            if (p < r)
            {
                int q = partition(p, r);
                quicksort(p, q - 1);
                quicksort(q + 1, r);
            }
        }

        public int partition(int p, int r)
        {
            int x = read(r);
            int i = p - 1;
            for (int j = p; j <= r - 1; j++)
            {
                int Aj = read(j);
                if (Aj <= x)
                {
                    i++;
                    int Ai = read(i);
                    write(i, Aj);
                    write(j, Ai);
                }
            }
            int Ai1 = read(i + 1);
            int Ar = read(r);
            write(i + 1, Ar);
            write(r, Ai1);
            return i + 1;
        }

        /// <summary>
        /// 读取并进行一步访存
        /// </summary>
        public void step()
        {
            if (curStep >= record.Count) return;

            // 获取该次访存
            Access access = record[curStep++];

            int lineIndex = access.index / Cache.wordNum;
            int wordIndex = access.index % Cache.wordNum;
            int memBaseIndex = lineIndex * Cache.wordNum;
            int setIndex = lineIndex % Cache.setNum;
            Set set = cacheRef.sets[setIndex];
            Line line = null;

            // 先访问cache
            for (int i = 0; i < Cache.lineNum; i++)
            {
                if (set.lines[i].valid && set.lines[i].memLine == lineIndex)
                {
                    // cache命中, 记录命中了set的哪个line
                    line = set.lines[i];
                    // 若是lru, 更改set的lruLinkedList
                    set.updateWhenHit(i);
                    break;
                }
            }

            if (line == null)
            {
                // cache没命中
                cacheMissCount++;
                line = set.lines[set.getReplacedLine()];

                // 如果要替换的line是valid的, 将mem对应word状态改为不在cache
                if (line.valid)
                {
                    int oldMemBaseIndex = line.memLine * Cache.wordNum;
                    for (int i = 0; i < Cache.wordNum; i++)
                    {
                        memRef.inCache[oldMemBaseIndex + i] = false;
                        if (line.dirty)  // 如果该line是脏的mem写入新值
                            memRef.wordValues[oldMemBaseIndex + i] = line.words[i].value;
                    }
                }
                else line.valid = true;

                // 设置memLine,与dirty属性
                line.memLine = lineIndex;
                line.dirty = false;

                // 将mem的值写入line, 对应word改为inCache
                for (int i = 0; i < Cache.wordNum; i++)
                {
                    line.words[i].value = memRef.wordValues[memBaseIndex + i];
                    memRef.inCache[memBaseIndex + i] = true;
                }
            }

            if (access.writeValue != null)
            {
                // 若是写, 需要将line的状态改为dirty, 还要改变对应word的值
                line.dirty = true;
                line.words[wordIndex].value = (int)access.writeValue;
            }
        }

        public void draw(Graphics graphics)
        {
            Size offset = new Size(0, 0);
            const int spaceFactor = 3;
            graphics.DrawString($"进度：{curStep}/{record.Count}", new Font("Arial", fontSize),
                Brushes.Black, progressLocation);
            offset.Height += fontSize * spaceFactor;
            graphics.DrawString($"miss：{cacheMissCount}/{curStep}", new Font("Arial", fontSize),
                Brushes.Black, progressLocation + offset);
            offset.Height += fontSize * spaceFactor;
            graphics.DrawString($"miss rate：{Decimal.Round((decimal)(curStep == 0 ? 0 : 100.0 * cacheMissCount / curStep), 4)}%", new Font("Arial", fontSize),
                Brushes.Black, progressLocation + offset);
            offset.Height += fontSize * spaceFactor;
            graphics.DrawString($"访存周期数：{curStep + cacheMissCount * cacheMissOverload}", new Font("Arial", fontSize),
                Brushes.Black, progressLocation + offset);
            offset.Height += fontSize * spaceFactor;
            graphics.DrawString($"cache miss overhead：{cacheMissOverload}", new Font("Arial", fontSize),
                Brushes.Black, progressLocation + offset);
            cacheRef.draw(graphics);
            memRef.draw(graphics);
        }
    }
}
