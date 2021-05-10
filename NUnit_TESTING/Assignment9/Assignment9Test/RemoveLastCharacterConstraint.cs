using NUnit.Framework.Constraints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment9Test
{
    public class RemoveLastCharacterConstraint : Constraint
    {
        public readonly string _expectedString;
        public RemoveLastCharacterConstraint(string expectedString)
        {
            _expectedString = expectedString.Remove(expectedString.Length - 1, 1);
            Description = $"Expected is {_expectedString}";
        }

        public override ConstraintResult ApplyTo<TActual>(TActual actual)
        {
            //Description = $"Actual is {actual}";
            if (typeof(TActual) != typeof(string))
                return new ConstraintResult(this, actual, ConstraintStatus.Error);
            if (_expectedString == actual.ToString())
                return new ConstraintResult(this, actual, ConstraintStatus.Success);
            else
                return new ConstraintResult(this, actual, ConstraintStatus.Failure);
        }

    }
    public class Is : NUnit.Framework.Is
    {
        public static RemoveLastCharacterConstraint RemoveLastCharacter(string expectedString)
        {
            return new RemoveLastCharacterConstraint(expectedString);
        }

    }
}
