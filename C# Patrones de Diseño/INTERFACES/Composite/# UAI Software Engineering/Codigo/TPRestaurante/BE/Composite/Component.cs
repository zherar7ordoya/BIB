﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;

namespace BE
{
    public abstract class Component : IComponent
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public ComponentType Type { get; set; }

        public PermissionType PermissionType { get; set; }

        public abstract IList<IComponent> Children { get; }

        public abstract void AddChild(IComponent c);

        public abstract void EmptyChildren();

        public override string ToString()
        {
            return Name;
        }

        public abstract object Clone();

    }
}
