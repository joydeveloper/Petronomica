using System;
using System.Collections.Generic;
using System.Text;

namespace SharedServices
{
    public abstract class Builder
    {
        public abstract void BuildPartA();
        public abstract void BuildPartB();
        public abstract void BuildPartC();
    }
    class Director
    {
        Builder builder;
        public Director(Builder builder)
        {
            this.builder = builder;
        }
        public Director()
        {

        }
        public void SetBuilder(Builder builder)
        {
            this.builder = builder;

        }
        public virtual void Construct()
        {
            builder.BuildPartA();
            builder.BuildPartB();
            builder.BuildPartC();
        }
    }
    class ConcreteBuilder : Builder
    {
        public override void BuildPartA()
        {

        }
        public override void BuildPartB()
        {

        }
        public override void BuildPartC()
        {

        }
    }
}
