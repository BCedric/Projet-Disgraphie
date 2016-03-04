namespace Projet_Disgraphie
{
    ///////////////////////////////////////////////////////////////////////////////
    // QueryDataForm.cs - Windows Forms test dialog for WintabDN
    //
    // Copyright (c) 2010, Wacom Technology Corporation
    //
    // Permission is hereby granted, free of charge, to any person obtaining a copy
    // of this software and associated documentation files (the "Software"), to deal
    // in the Software without restriction, including without limitation the rights
    // to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
    // copies of the Software, and to permit persons to whom the Software is
    // furnished to do so, subject to the following conditions:
    //
    // THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
    // IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
    // FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
    // AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
    // LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
    // OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
    // THE SOFTWARE.
    ///////////////////////////////////////////////////////////////////////////////
    using System;
    using WintabDN;


    public partial class QueryDataForm
    {
        private CWintabContext m_logContext = null;
        private CWintabData m_wtData = null;

        UInt32 m_maxPackets = 10;
        const bool REMOVE = true;

        public QueryDataForm()
        {

            try
            {
                // Open a Wintab context that does not send Wintab data events.
                m_logContext = OpenQueryDigitizerContext();

                // Create a data object.
                m_wtData = new CWintabData(m_logContext);

                m_wtData.SetWTPacketEventHandler(MyWTPacketEventHandler);

                //TraceMsg("Press \"Test\" and touch pen to tablet.\n");
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
        }

        private CWintabContext OpenQueryDigitizerContext()
        {
            bool status = false;
            CWintabContext logContext = null;

            try
            {
                // Get the default digitizing context.  Turn off events.  Control system cursor.
                logContext = CWintabInfo.GetDefaultDigitizingContext(ECTXOptionValues.CXO_SYSTEM);

                logContext.Options |= (uint)ECTXOptionValues.CXO_MESSAGES;
                logContext.Options &= ~(uint)ECTXOptionValues.CXO_SYSTEM;

                if (logContext == null)
                {

                    //System.Diagnostics.Debug.WriteLine("FAILED to get default digitizing context.");
                    return null;
                }

                // Modify the digitizing region.
                logContext.Name = "WintabDN Query Data Context";

                //WintabAxis tabletX = CWintabInfo.GetTabletAxis(EAxisDimension.AXIS_X);
                //WintabAxis tabletY = CWintabInfo.GetTabletAxis(EAxisDimension.AXIS_Y);

                //// Output X/Y values 1-1 with tablet dimensions.
                // logContext.OutOrgX = logContext.OutOrgY = 0;
                // logContext.OutExtX = tabletX.axMax;
                // logContext.OutExtY = tabletY.axMax;

                logContext.SysOrgX = logContext.SysOrgY = 0;

                // Open the context, which will also tell Wintab to send data packets.
                status = logContext.Open();


                //System.Diagnostics.Debug.WriteLine("Context Open: " + (status ? "PASSED [ctx=" + logContext.HCtx + "]" : "FAILED"));
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }

            return logContext;
        }



        /// <summary>
        /// Responds to pen data by removing or peek/flushing data.
        /// </summary>
        /// <param name="sender_I"></param>
        /// <param name="eventArgs_I"></param>
        public void MyWTPacketEventHandler(Object sender_I, MessageReceivedEventArgs eventArgs_I)
        {
            UInt32 numPkts = 0;

            //System.Diagnostics.Debug.WriteLine("Received WT_PACKET event");
            if (m_wtData == null)
            {
                return;
            }


            try
            {
                // If removeData is true, packets are removed as they are read.
                // If removeData is false, peek at packets only (packets flushed below).
                WintabPacket[] packets = m_wtData.GetDataPackets(m_maxPackets, false, ref numPkts);

                if (numPkts > 0)
                {


                    // If the peek button was pressed, then flush the packets we just peeked at.

                    m_wtData.FlushDataPackets(numPkts);

                }
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
        }




    }

}
