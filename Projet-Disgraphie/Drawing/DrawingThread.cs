﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Projet_Disgraphie.Utils;

namespace Projet_Disgraphie.Drawing
{
    class DrawingThread
    {
        //Synchronized threads datas
        private Thread thread;
        private static Object lockObject = new Object();
        private List<DrawingPoint> synchronizedList;

        //Graphical datas
        private Graphics g;
        private int drawSpeed = 50;
        private Point previousP = Point.Empty;
        private long previousTime = 0;
        private long pauseTime = 20;
        private Pen pen;

        public DrawingThread(PictureBox pictureBox)
        {
            this.g = pictureBox.CreateGraphics();
        }

        private void Reset()
        {
            // LIST
            if(synchronizedList == null)
            {
                synchronizedList = new List<DrawingPoint>();
            }
            synchronizedList.Clear();

            // THREAD
            if (thread == null)
            {
                thread = new Thread(new ThreadStart(Draw));
            }


            //GRAPHIC
            Color color = Color.Black;
            SolidBrush myBrush = new SolidBrush(color);
            pen = new Pen(myBrush,1);
            pen.StartCap = LineCap.Round;
            pen.EndCap = LineCap.Round;
            pen.DashStyle = DashStyle.Solid;
        }

        public void Start()
        {
            Reset();
            thread.Start();
        }



        private void Draw()
        {
            // Tant que le thread n'est pas tué, on travaille
            Console.WriteLine("Start thread...");
            while (Thread.CurrentThread.IsAlive)
            {
                Thread.Sleep(drawSpeed);

                DrawingPoint[] copyList = new DrawingPoint[synchronizedList.Count];
                if (copyList.Length > 0)
                {
                    //Lock part for synchronizedList access
                    lock (lockObject)
                    {
                        this.synchronizedList.CopyTo(copyList);
                        synchronizedList.Clear();
                    }



                    // Affichage dans la console
                    Console.WriteLine("Nb point recu : " + copyList.Length);
                    foreach (DrawingPoint p in copyList)
                    {
                        DrawSinglePoint(p);
                    }
                }

                //Pause detection
                long currentTime = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
                if(previousTime + pauseTime < currentTime)
                {
                    previousP = Point.Empty;
                }
            }
        }

        private void DrawSinglePoint(DrawingPoint p)
        {
            Point currentP = new Point(p.X, p.Y);
            if (previousP != Point.Empty)
            {
                pen.Width = (float)Math.Sqrt(p.pression/2)/4;
                this.g.DrawLine(pen, previousP, currentP);
            }
            previousP = currentP;
            previousTime = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
        }

        public void AddPoint(DrawingPoint p)
        {
            //Lock part for synchronizedList access
            lock (lockObject)
            {
                synchronizedList.Add(p);
            }
        }

    }
}
