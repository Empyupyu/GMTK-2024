using System;

namespace SOLID
{
    public class LiskovSubstistutionPrinciple
    {
        /// <summary>
        /// Данный принцип гласит, что «вы должны иметь возможность использовать любой производный 
        /// класс вместо родительского класса и вести себя с ним таким же образом без внесения изменений».
        /// Этот принцип прост, но очень важен для понимания.
        /// Класс Child не должен нарушать определение типа родительского класса и его поведение.
        /// </summary>

        public void Case()
        {
            CharacterWarrior warrior = new CharacterWarrior();
            NPC npc = new NPC();

            GetCharacterClass(warrior);
            GetCharacterClass(npc);

            DealDamage(warrior);
        }

        private string GetCharacterClass(IClass charcaterClass)
        {
           return charcaterClass.GetClass();
        }

        private void DealDamage(IDamageble damageble)
        {
            damageble.TakeDamage(1);
        }
    }

    #region BadCase
    //пример нарушения LSP
    public abstract class Character
    {
        public float Health { get; set; }

        public virtual string GetClass()
        {
            return "Base Healer";
        }

        public virtual void TakeDamage(float damage)
        {
            Health -= damage;
        }
    }

    public class CharacterOne : Character
    {
        public override string GetClass()
        {
            return "Warrior";
        }

        public override void TakeDamage(float damage)
        {
            Health -= damage * .9f;
        }
    }

    public class CharacterNPC : Character
    {
        public override string GetClass()
        {
            return "NPC Mage";
        }

        public override void TakeDamage(float damage)
        {
            new NullReferenceException();
        }
    }

    #endregion

    #region GoodCase
    //пример реализации LSP 
    public interface IDamageble
    {
        public float Health { get; set; }

        public void TakeDamage(float damage);
    }

    public interface IClass
    {
        public string GetClass();
    }

    public class CharacterWarrior : IClass, IDamageble
    {
        public float Health { get; set; }

        public string GetClass()
        {
            return "Warrior";
        }

        public void TakeDamage(float damage)
        {
            Health -= damage * .9f;
        }
    }

    public class NPC : IClass
    {
        public string GetClass()
        {
            return "NPC Killer";
        }
    }
    #endregion
}


