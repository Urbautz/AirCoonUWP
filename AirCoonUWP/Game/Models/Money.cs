using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AirCoon.Game.Models
{
    [Serializable]
    public class Money
        : ISerializable
    {

        private decimal _Value;
        public decimal Value
        {
            set { this._Value = value; }
            get { return Decimal.Round(_Value, 2); }
        }

  public decimal PrecisionValue
        {
            get { return this._Value; }
        }

        // Constructor with value
        public Money(Decimal value)
        {
            this._Value = value;
        } // End Constructor

        // Constructor with value
        public Money(int value)
        {
            this._Value = (Decimal)value;
        } // End Constructor


        public Money(Int64 value)
        {
            this._Value = (Decimal)value;
        } // End Constructor


        public Money(SerializationInfo info, StreamingContext ctxt)
        {
            this._Value = info.GetDecimal("Value");
        }

        public static Money operator +(Money m1, Money m2)
        {
            return new Money(m1.PrecisionValue + m2.PrecisionValue);
        }
        public static Money operator -(Money m1, Money m2)
        {
            return new Money(m1.PrecisionValue - m2.PrecisionValue);
        }

        public static bool operator ==(Money m1, Money m2)
        {
            if (m1 is null && m2 is null) return true;
            else if (m1 is null) return false;
            else if (m2 is null) return false;
            else return m1.Value == m2.Value;
            /*try { 
                return m1.Value == m2.Value;
            } catch(Exception e)
            {
                return true;
            }*/
        }
        public static bool operator !=(Money m1, Money m2)
        {
            return m1.Value != m2.Value;
        }
        public static bool operator >(Money m1, Money m2)
        {
            return m1.Value > m2.Value;
        }
        public static bool operator <(Money m1, Money m2)
        {
            return m1.Value < m2.Value;
        }
        public static bool operator <=(Money m1, Money m2)
        {
            return m1.Value <= m2.Value;
        }
        public static bool operator >=(Money m1, Money m2)
        {
            return m1.Value >= m2.Value;
        }

        public override bool Equals(object obj)
        {
            var money = obj as Money;
            return money != null &&
                   PrecisionValue == money.PrecisionValue;
        }

        public override int GetHashCode()
        {
            return 1363966828 + PrecisionValue.GetHashCode();
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Value", PrecisionValue);
        }
    }
}
