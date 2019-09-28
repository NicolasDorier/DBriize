/* 
  Copyright (C) 2012 DBriize.tiesky.com / Alex Solovyov / Ivars Sudmalis.
  It's a free software for those, who think that it should be free.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DBriize.Utils
{
    public class DbThreadsGator:IDisposable
    {

        System.Threading.ManualResetEvent gate = null;

        public DbThreadsGator(bool gateIsOpen, bool isSingleThread)
        {
			if (!isSingleThread)
			{
				if (gateIsOpen)
					gate = new System.Threading.ManualResetEvent(true);
				else
					gate = new System.Threading.ManualResetEvent(false);
			}
        }

        /// <summary>
        /// Sets Gate in the code
        /// </summary>
        /// <returns></returns>
        public bool PutGateHere()
        {
            return gate == null || gate.WaitOne();
        }

        ///// <summary>
        ///// If gate is closed then it will be closed timeout time in milliseconds
        ///// </summary>
        ///// <param name="milliseconds"></param>
        ///// <param name="milliseconds">exitContext</param>
        ///// <returns></returns>
        //public bool PutGateHere(int milliseconds, bool exitContext)
        //{
        //    return gate.WaitOne(milliseconds, exitContext);
        //}

        public bool OpenGate()
        {
            return gate == null || gate.Set();
        }

        public bool CloseGate()
        {
            return gate == null || gate.Reset();
        }

        public void Dispose()
        {
            gate?.Dispose();            
        }
    }
}
