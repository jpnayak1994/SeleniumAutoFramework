using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumAutoFramework.Base
{
   public  class BaseStep:BasePage
    {
        public BaseStep(ParallelConfig parallelConfig, LoggingStep loggingStep) : base(parallelConfig,loggingStep)
        {

        }
    }
}
