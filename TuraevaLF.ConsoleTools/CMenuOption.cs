using System;

namespace TuraevaLF.ConsoleTools
{
    internal class CMenuOption
    {
        internal readonly string Name;
        internal readonly Action Execute;
        protected internal object State { get; protected set; }

        internal CMenuOption(string name, Action<object> execute)
            : this(name, execute, null)
        {
        }

        internal CMenuOption(string name, Action<object> execute, object state)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("Имя опции не может быть пустым.", "name");
            }
            if (execute == null)
            {
                throw new ArgumentNullException("execute");
            }

            Name = name;
            State = state;
            Execute = () => execute(State);
        }
    }

    internal class CMenuOption<TState> : CMenuOption
    {
        internal CMenuOption(string name, Action<TState> execute, TState state)
            : base(name, o => execute((TState)o), state)
        {
        }
    }
}