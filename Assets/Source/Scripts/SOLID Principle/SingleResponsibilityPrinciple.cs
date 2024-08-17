using UnityEngine;

namespace SOLID
{
    public sealed class SingleResponsibilityPrinciple
    {
        /// <summary>
        ///   Этот принцип означает, что каждый класс или подобная структура в вашем коде должна отвечать только за одну цель.
        ///   Все члены этого класса должны быть связаны одной целью. Наш класс не должен быть похож на швейцарский нож,
        ///   в котором при изменении одного из членов нужно изменять весь инструментарий. Это не означает,
        ///   что ваши классы должны содержать только один метод или свойство. Может быть много членов, если они относятся к единой ответственности.
        ///   
        ///   Принцип единой ответственности дает нам хороший способ определения классов на этапе проектирования приложения и
        ///   заставляет вас думать о всех способах изменения класса.Хорошее разделение обязанностей выполняется только тогда,
        ///   когда имеется полная картина того, как приложение должно работать.
        /// </summary>

        public void Case()
        {
            Tangerine tangerine = new Tangerine(new TangerinePeel(Color.yellow));
        }
    }

    #region BadCase
    //пример нарушения SRP
    public class TangerineAndTangerinePeel
    {
        public float Size { get; set; }
        public Color Color { get; private set; }
        public bool HasPeel { get; private set; }

        public void Scaling()
        {
            Size += 1f * Time.deltaTime;
        }

        public void Peeling()
        {
            HasPeel = false;
        }
    }
    #endregion

    #region GoodCase
    //пример реализации SRP 
    public class Tangerine
    {
        public float Size { get; private set; }
        public TangerinePeel TangerinePeel { get; private set; }

        public Tangerine(TangerinePeel tangerinePeel)
        {
            TangerinePeel = tangerinePeel;
        }

        public void Scaling()
        {
            Size += 1f * Time.deltaTime;
        }
    }

    public class TangerinePeel
    {
        public Color Color { get; private set; }
        public bool HasPeel { get; private set; }

        public TangerinePeel(Color color)
        {
            Color = color;
            HasPeel = true;
        }

        public void Peeling()
        {
            HasPeel = false;
        }
    }
    #endregion
}
