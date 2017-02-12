using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics;

namespace WMViewModelCommon
{
    public class GenericCommandHandler : ICommand
    {
        private readonly Action<object> _execute;
        private readonly Func<object, bool> _canExecute;
        /// <summary>
        /// Initializes a new instance of the DelegateCommand class that 
        /// can always execute.
        /// </summary>
        /// <param name="execute">The execution logic.</param>
        /// <exception cref="ArgumentNullException">If the execute argument is null.</exception>
        public GenericCommandHandler(Action<object> execute)
            : this(execute, null)
        {
        }
        /// <summary>
        /// Initialize a new instance of the DelegateCommand class
        /// </summary>
        /// <param name="execute">the execution logic</param>
        /// <param name="canExecute">the execution status logic</param>
        /// <exception cref="ArgumentNullException">if the execution logic is null</exception>
        public GenericCommandHandler(Action<object> execute, Func<object, bool> canExecute)
        {
            if (execute == null)
                throw new ArgumentNullException("Execute");
            _execute = execute;
            _canExecute = canExecute;
        }
        /// <summary>
        /// defines the method that determines whether the command can run in its current state
        /// </summary>
        /// <param name="parameter">the command parameter</param>
        /// <returns>true if this command can be executed; otherwise, return false</returns>
        public bool CanExecute(object parameter)
        {
            return _canExecute == null ? true : _canExecute(parameter);
        }
        /// <summary>
        /// Occurs when changes occur that affect whether the command should execute
        /// </summary>
        public event EventHandler CanExecuteChanged;

        /// <summary>
        /// raise the <see cref="CanExecuteChanged"/>
        /// </summary>
        [SuppressMessage("Microsoft.Design", "CA1030:UseEventsWhereAppropriate",
            Justification = "This cannot be an event")]
        public void RaiseCanExecuteChanged()
        {
            var handler = CanExecuteChanged;
            if (handler != null)
                handler(this, EventArgs.Empty);
        }
        /// <summary>
        /// define the method to be called when  the command is invoked
        /// </summary>
        /// <param name="parameter">command parameter</param>
        public void Execute(object parameter)
        {
            if (CanExecute(parameter))
            {
                _execute(parameter);
            }
        }
    }
}
