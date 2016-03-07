using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Projet_Disgraphie.Datas;
using Projet_Disgraphie.Drawing;
using WintabDN;

namespace Projet_Disgraphie
{


qskbqkjfbqsbckjb
    public partial class Form1 : Form
    {
        private CWintabContext m_logContext = null;
        private CWintabData m_wtData = null;
        private Criteres gestionnaireDonnees = new Criteres();


        private DrawingThread drawingThread;
        private Criteres criteres;



        // These constants can be used to force Wintab X/Y data to map into a
        // a 10000 x 10000 grid, as an example of mapping tablet data to values
        // that make sense for your application.
        private const Int32 m_TABEXTX = 10000;
        private const Int32 m_TABEXTY = 10000;

        public object TextBoxVitesseMoyenne { get; private set; }

        public Form1()
        {
            InitializeComponent();
            InitData();

            bool controlSystemCursor = true;
            this.FormClosing += new FormClosingEventHandler(TestForm_FormClosing);
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            InitDataCapture(m_TABEXTX, m_TABEXTY, controlSystemCursor);

        }

        private void InitData()
        {
            drawingThread = new DrawingThread(this.picBoard);
            drawingThread.Start();
            criteres = new Criteres();
            criteres.Start();

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.Save();
        }
       /*
        private void button1_Click(object sender, EventArgs e)
        {

           // CloseCurrentContext();
            Test_IsWintabAvailable();
            Test_GetDeviceInfo();
            Test_GetDefaultDigitizingContext();
            Test_GetDefaultSystemContext();
            Test_GetDefaultDeviceIndex();
            Test_GetDeviceAxis();
            Test_GetDeviceOrientation();
            Test_GetDeviceRotation();
            Test_GetNumberOfDevices();
            Test_IsStylusActive();
            Test_GetStylusName();
            Test_GetExtensionMask();
            Test_Context();
            Test_DataPacketQueueSize();
            Test_MaxPressure();
            Test_GetDataPackets(1);
            Test_QueryDataPackets();
        }*/
        private void TestForm_FormClosing(Object sender, FormClosingEventArgs e)
        {
            CloseCurrentContext();
        }
        private void CloseCurrentContext()
        {
            try
            {

                if (m_logContext != null)
                {
                    m_logContext.Close();
                    m_logContext = null;
                    m_wtData = null;
                }

            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString());
            }
        }

        /*
        private void Test_IsWintabAvailable()
        {
            if (CWintabInfo.IsWintabAvailable())
            {
                Console.Write("Wintab was found!\n");
            }
            else
            {
                Console.Write("Wintab was not found!\nCheck to see if tablet driver service is running.\n");
            }
        }

        ///////////////////////////////////////////////////////////////////////
        private void Test_GetDeviceInfo()
        {
            //Console.Write("DeviceInfo: " + CWintabInfo.GetDeviceInfo() + "\n");
            string devInfo = CWintabInfo.GetDeviceInfo();
            Console.Write("DeviceInfo: " + devInfo + "\n");
        }


        ///////////////////////////////////////////////////////////////////////
        private void Test_GetDefaultDigitizingContext()
        {
            CWintabContext context = CWintabInfo.GetDefaultDigitizingContext();

            Console.Write("Default Digitizing Context:\n");
            Console.Write("\tSysOrgX, SysOrgY, SysExtX, SysExtY\t[" +
                context.SysOrgX + "," + context.SysOrgY + "," +
                context.SysExtX + "," + context.SysExtY + "]\n");

            Console.Write("\tInOrgX, InOrgY, InExtX, InExtY\t[" +
                context.InOrgX + "," + context.InOrgY + "," +
                context.InExtX + "," + context.InExtY + "]\n");

            Console.Write("\tOutOrgX, OutOrgY, OutExtX, OutExt\t[" +
                context.OutOrgX + "," + context.OutOrgY + "," +
                context.OutExtX + "," + context.OutExtY + "]\n");
        }

        ///////////////////////////////////////////////////////////////////////
        private void Test_GetDefaultSystemContext()
        {
            CWintabContext context = CWintabInfo.GetDefaultSystemContext();

            Console.Write("Default System Context:\n");
            Console.Write("\tSysOrgX, SysOrgY, SysExtX, SysExtY\t[" +
                context.SysOrgX + "," + context.SysOrgY + "," +
                context.SysExtX + "," + context.SysExtY + "]\n");

            Console.Write("\tInOrgX, InOrgY, InExtX, InExtY\t[" +
                context.InOrgX + "," + context.InOrgY + "," +
                context.InExtX + "," + context.InExtY + "]\n");

            Console.Write("\tOutOrgX, OutOrgY, OutExtX, OutExt\t[" +
                context.OutOrgX + "," + context.OutOrgY + "," +
                context.OutExtX + "," + context.OutExtY + "]\n");
        }

        ///////////////////////////////////////////////////////////////////////
        private void Test_GetDefaultDeviceIndex()
        {
            Int32 devIndex = CWintabInfo.GetDefaultDeviceIndex();

            Console.Write("Default device index is: " + devIndex + (devIndex == -1 ? " (virtual device)\n" : "\n"));
        }

        ///////////////////////////////////////////////////////////////////////
        private void Test_GetDeviceAxis()
        {
            WintabAxis axis;

            // Get virtual device axis for X, Y and Z.
            axis = CWintabInfo.GetDeviceAxis(-1, EAxisDimension.AXIS_X);

            Console.Write("Device axis X for virtual device:\n");
            Console.Write("\taxMin, axMax, axUnits, axResolution: " + axis.axMin + "," + axis.axMax + "," + axis.axUnits + "," + axis.axResolution.ToString() + "\n");

            axis = CWintabInfo.GetDeviceAxis(-1, EAxisDimension.AXIS_Y);
            Console.Write("Device axis Y for virtual device:\n");
            Console.Write("\taxMin, axMax, axUnits, axResolution: " + axis.axMin + "," + axis.axMax + "," + axis.axUnits + "," + axis.axResolution.ToString() + "\n");

            axis = CWintabInfo.GetDeviceAxis(-1, EAxisDimension.AXIS_Z);
            Console.Write("Device axis Z for virtual device:\n");
            Console.Write("\taxMin, axMax, axUnits, axResolution: " + axis.axMin + "," + axis.axMax + "," + axis.axUnits + "," + axis.axResolution.ToString() + "\n");
        }

        ///////////////////////////////////////////////////////////////////////
        private void Test_GetDeviceOrientation()
        {
            bool tiltSupported = false;
            WintabAxisArray axisArray = CWintabInfo.GetDeviceOrientation(out tiltSupported);
            Console.Write("Device orientation:\n");
            Console.Write("\ttilt supported for current tablet: " + (tiltSupported ? "YES\n" : "NO\n"));

            if (tiltSupported)
            {
                for (int idx = 0; idx < axisArray.array.Length; idx++)
                {
                    Console.Write("\t[" + idx + "] axMin, axMax, axResolution, axUnits: " +
                        axisArray.array[idx].axMin + "," +
                        axisArray.array[idx].axMax + "," +
                        axisArray.array[idx].axResolution + "," +
                        axisArray.array[idx].axUnits + "\n");
                }
            }
        }

        ///////////////////////////////////////////////////////////////////////
        private void Test_GetDeviceRotation()
        {
            bool rotationSupported = false;
            WintabAxisArray axisArray = CWintabInfo.GetDeviceRotation(out rotationSupported);
            Console.Write("Device rotation:\n");
            Console.Write("\trotation supported for current tablet: " + (rotationSupported ? "YES\n" : "NO\n"));

            if (rotationSupported)
            {
                for (int idx = 0; idx < axisArray.array.Length; idx++)
                {
                    Console.Write("\t[" + idx + "] axMin, axMax, axResolution, axUnits: " +
                        axisArray.array[idx].axMin + "," +
                        axisArray.array[idx].axMax + "," +
                        axisArray.array[idx].axResolution + "," +
                        axisArray.array[idx].axUnits + "\n");
                }
            }
        }

        ///////////////////////////////////////////////////////////////////////
        private void Test_GetNumberOfDevices()
        {
            UInt32 numDevices = CWintabInfo.GetNumberOfDevices();
            Console.Write("Number of tablets connected: " + numDevices + "\n");
        }


        ///////////////////////////////////////////////////////////////////////
        private void Test_IsStylusActive()
        {
            bool isStylusActive = CWintabInfo.IsStylusActive();
            Console.Write("Is stylus active: " + (isStylusActive ? "YES\n" : "NO\n"));
        }


        ///////////////////////////////////////////////////////////////////////
        private void Test_GetStylusName()
        {
            Console.Write("Stylus name (puck):   " + CWintabInfo.GetStylusName(EWTICursorNameIndex.CSR_NAME_PUCK) + "\n");
            Console.Write("Stylus name (pen):    " + CWintabInfo.GetStylusName(EWTICursorNameIndex.CSR_NAME_PRESSURE_STYLUS) + "\n");
            Console.Write("Stylus name (eraser): " + CWintabInfo.GetStylusName(EWTICursorNameIndex.CSR_NAME_ERASER) + "\n");
        }

        ///////////////////////////////////////////////////////////////////////
        private void Test_GetExtensionMask()
        {
            Console.Write("Extension touchring mask:   0x" + CWintabExtensions.GetWTExtensionMask(EWTXExtensionTag.WTX_TOUCHRING).ToString("x") + "\n");
            Console.Write("Extension touchstring mask: 0x" + CWintabExtensions.GetWTExtensionMask(EWTXExtensionTag.WTX_TOUCHSTRIP).ToString("x") + "\n");
            Console.Write("Extension express key mask: 0x" + CWintabExtensions.GetWTExtensionMask(EWTXExtensionTag.WTX_EXPKEYS2).ToString("x") + "\n");
        }

        ///////////////////////////////////////////////////////////////////////
        private void Test_Context()
        {
            bool status = false;
            CWintabContext logContext = null;

            try
            {


                status = logContext.Enable(true);
                Console.Write("Context Enable: " + (status ? "PASSED" : "FAILED") + "\n");

                status = logContext.SetOverlapOrder(false);
                Console.Write("Context SetOverlapOrder to bottom: " + (status ? "PASSED" : "FAILED") + "\n");
                status = logContext.SetOverlapOrder(true);
                Console.Write("Context SetOverlapOrder to top: " + (status ? "PASSED" : "FAILED") + "\n");

                Console.Write("Modified Context:\n");
                Console.Write("  Name: " + logContext.Name + "\n");
                Console.Write("  Options: " + logContext.Options + "\n");
                Console.Write("  Status: " + logContext.Status + "\n");
                Console.Write("  Locks: " + logContext.Locks + "\n");
                Console.Write("  MsgBase: " + logContext.MsgBase + "\n");
                Console.Write("  Device: " + logContext.Device + "\n");
                Console.Write("  PktRate: 0x" + logContext.PktRate.ToString("x") + "\n");
                Console.Write("  PktData: 0x" + ((uint)logContext.PktData).ToString("x") + "\n");
                Console.Write("  PktMode: 0x" + ((uint)logContext.PktMode).ToString("x") + "\n");
                Console.Write("  MoveMask: " + logContext.MoveMask + "\n");
                Console.Write("  BZtnDnMask: 0x" + logContext.BtnDnMask.ToString("x") + "\n");
                Console.Write("  BtnUpMask: 0x" + logContext.BtnUpMask.ToString("x") + "\n");
                Console.Write("  InOrgX: " + logContext.InOrgX + "\n");
                Console.Write("  InOrgY: " + logContext.InOrgY + "\n");
                Console.Write("  InOrgZ: " + logContext.InOrgZ + "\n");
                Console.Write("  InExtX: " + logContext.InExtX + "\n");
                Console.Write("  InExtY: " + logContext.InExtY + "\n");
                Console.Write("  InExtZ: " + logContext.InExtZ + "\n");
                Console.Write("  OutOrgX: " + logContext.OutOrgX + "\n");
                Console.Write("  OutOrgY: " + logContext.OutOrgY + "\n");
                Console.Write("  OutOrgZ: " + logContext.OutOrgZ + "\n");
                Console.Write("  OutExtX: " + logContext.OutExtX + "\n");
                Console.Write("  OutExtY: " + logContext.OutExtY + "\n");
                Console.Write("  OutExtZ: " + logContext.OutExtZ + "\n");
                Console.Write("  SensX: " + logContext.SensX + "\n");
                Console.Write("  SensY: " + logContext.SensY + "\n");
                Console.Write("  SensZ: " + logContext.SensZ + "\n");
                Console.Write("  SysMode: " + logContext.SysMode + "\n");
                Console.Write("  SysOrgX: " + logContext.SysOrgX + "\n");
                Console.Write("  SysOrgY: " + logContext.SysOrgY + "\n");
                Console.Write("  SysExtX: " + logContext.SysExtX + "\n");
                Console.Write("  SysExtY: " + logContext.SysExtY + "\n");
                Console.Write("  SysSensX: " + logContext.SysSensX + "\n");
                Console.Write("  SysSensY: " + logContext.SysSensY + "\n");
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
            }
            finally
            {
                if (logContext != null)
                {
                    status = logContext.Close();
                    Console.Write("Context Close: " + (status ? "PASSED" : "FAILED") + "\n");
                }
            }

        }

        private void Test_DataPacketQueueSize()
        {
            bool status = false;
            UInt32 numPackets = 0;
            CWintabContext logContext = null;

            try
            {


                if (logContext == null)
                {
                    Console.Write("Test_DataPacketQueueSize: FAILED OpenTestDigitizerContext - bailing out...\n");
                    return;
                }

                CWintabData wtData = new CWintabData(logContext);
                Console.Write("Creating CWintabData object: " + (wtData != null ? "PASSED" : "FAILED") + "\n");
                if (wtData == null)
                {
                    throw new Exception("Could not create CWintabData object.");
                }

                numPackets = wtData.GetPacketQueueSize();
                Console.Write("Initial packet queue size: " + numPackets + "\n");

                status = wtData.SetPacketQueueSize(17);
                Console.Write("Setting packet queue size: " + (status ? "PASSED" : "FAILED") + "\n");

                numPackets = wtData.GetPacketQueueSize();
                Console.Write("Modified packet queue size: " + numPackets + "\n");
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
            }
            finally
            {
                if (logContext != null)
                {
                    status = logContext.Close();
                    Console.Write("Context Close: " + (status ? "PASSED" : "FAILED") + "\n");
                }
            }
        }

        ///////////////////////////////////////////////////////////////////////
        private void Test_MaxPressure()
        {
            Console.Write("Max normal pressure is: " + CWintabInfo.GetMaxPressure() + "\n");
            Console.Write("Max tangential pressure is: " + CWintabInfo.GetMaxPressure(false) + "\n");
        }

        ///////////////////////////////////////////////////////////////////////
        private void Test_GetDataPackets(UInt32 maxNumPkts_I)
        {
            // Set up to capture/display maxNumPkts_I packet at a time.
            m_maxPkts = maxNumPkts_I;

            // Open a context and try to capture pen data.
            InitDataCapture();

            // Touch pen to the tablet.  You should see data appear in the TestForm window.
        }

        private void Test_QueryDataPackets()
        {
            QueryDataForm qdForm = new QueryDataForm();


        }
        */
        private void InitDataCapture(int ctxWidth_I = m_TABEXTX, int ctxHeight_I = m_TABEXTY, bool ctrlSysCursor_I = true)
        {
            try
            {
                // Close context from any previous test.
                CloseCurrentContext();

                m_logContext = OpenTestSystemContext(ctxWidth_I, ctxHeight_I, ctrlSysCursor_I);

                if (m_logContext == null)
                {
                    Console.Write("Test_DataPacketQueueSize: FAILED OpenTestSystemContext - bailing out...\n");
                    return;
                }

                // Create a data object and set its WT_PACKET handler.
                m_wtData = new CWintabData(m_logContext);
                m_wtData.SetWTPacketEventHandler(MyWTPacketEventHandler);
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
            }
        }
        private CWintabContext OpenTestSystemContext(int width_I = m_TABEXTX, int height_I = m_TABEXTY, bool ctrlSysCursor = true)
        {
            bool status = false;
            CWintabContext logContext = null;

            try
            {
                // Get the default system context.
                // Default is to receive data events.
                //logContext = CWintabInfo.GetDefaultDigitizingContext(ECTXOptionValues.CXO_MESSAGES);
                logContext = CWintabInfo.GetDefaultSystemContext(ECTXOptionValues.CXO_MESSAGES);

                // Set system cursor if caller wants it.
                if (ctrlSysCursor)
                {
                    logContext.Options |= (uint)ECTXOptionValues.CXO_SYSTEM;
                }
                else
                {
                    logContext.Options &= ~(uint)ECTXOptionValues.CXO_SYSTEM;
                }

                if (logContext == null)
                {
                    Console.Write("FAILED to get default digitizing context.\n");
                    return null;
                }

                // Modify the digitizing region.
                logContext.Name = "WintabDN Event Data Context";

                WintabAxis tabletX = CWintabInfo.GetTabletAxis(EAxisDimension.AXIS_X);
                WintabAxis tabletY = CWintabInfo.GetTabletAxis(EAxisDimension.AXIS_Y);

                logContext.InOrgX = 0;
                logContext.InOrgY = 0;
                logContext.InExtX = tabletX.axMax;
                logContext.InExtY = tabletY.axMax;

                // SetSystemExtents() is (almost) a NO-OP redundant if you opened a system context.
                SetSystemExtents(ref logContext);

                // Open the context, which will also tell Wintab to send data packets.
                status = logContext.Open();

                Console.Write("Context Open: " + (status ? "PASSED [ctx=" + logContext.HCtx + "]" : "FAILED") + "\n");
            }
            catch (Exception ex)
            {
                Console.Write("OpenTestDigitizerContext ERROR: " + ex.ToString());
            }

            return logContext;
        }

        public void MyWTPacketEventHandler(Object sender_I, MessageReceivedEventArgs eventArgs_I)
        {
            //System.Diagnostics.Debug.WriteLine("Received WT_PACKET event");
            if (m_wtData == null)
            {
                return;
            }

            try
            {
                uint pktID = (uint)eventArgs_I.Message.WParam;

                WintabPacket pkt = m_wtData.GetDataPacket((uint)eventArgs_I.Message.LParam, pktID);

                if (pkt.pkContext != 0)
                {
                    if (pkt.pkNormalPressure != 0)
                    {
                        Point convertedP = picBoard.PointToClient(new Point(pkt.pkX, pkt.pkY));
                        drawingThread.AddPoint(new DrawingPoint(convertedP.X, convertedP.Y, pkt.pkNormalPressure));
                        criteres.AddPoint(new DataPoint(convertedP.X, convertedP.Y, DateTime.Now.Millisecond));

                    }


                   //String msg = "SCREEN: pkX: " + pkt.pkX + ", pkY:" + pkt.pkY + ", pressure: " + pkt.pkNormalPressure + " , tangent presure: " + pkt.pkTangentPressure;
                   //   String msg = gestionnaireDonnees.GetCriteresToString();
                    TextBoxVitesseActuelle.Text = criteres.GetVitesseActuelle().ToString();
                    textBoxVitesseMoyenne.Text = criteres.GetVitesseMoyenne().ToString();
                    textBoxNbPoint.Text = criteres.GetNbPoint().ToString();
                    textBoxPression.Text = pkt.pkNormalPressure.ToString();
                   // Console.WriteLine(msg);
                   // AfficherDonnee(msg);
                }

            }
            catch (Exception ex)
            {
                throw new Exception("FAILED to get packet data: " + ex.ToString());
            }
        }
        private void SetSystemExtents(ref CWintabContext logContext)
        {
            //TODO Rectangle rect = new Rectangle(int.MaxValue, int.MaxValue, int.MinValue, int.MinValue);

            //TODO foreach (Screen screen in Screen.AllScreens)
            //TODO    rect = Rectangle.Union(rect, screen.Bounds);

            //TODO logContext.OutOrgX = rect.Left;
            //TODO logContext.OutOrgY = rect.Top;
            //TODO logContext.OutExtX = rect.Width;
            //TODO logContext.OutExtY = rect.Height;

            // In Wintab, the tablet origin is lower left.  Move origin to upper left
            // so that it coincides with screen origin.
            logContext.OutExtY = -logContext.OutExtY;
        }

    }
}
