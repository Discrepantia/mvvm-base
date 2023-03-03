﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;

namespace MVVM.Base
{
    public class SetPropertyCommand : ContextMarkupCommand
    {
        public string PropertyName { get; set; }

        public Binding Target { get; set; }

        protected override void Execute(object parameter)
        {
            object target = TargetInstance.DataContext;
            if (TargetInstance != null)
            {
                if (Target != null)
                {
                    var dummy = new BindingDummy(target);
                    target = dummy.GetValue(Target) as ICommand;
                }

                target?.GetType().GetProperty(PropertyName)?.SetValue(target, parameter);
                
            }

        }
    }
}
