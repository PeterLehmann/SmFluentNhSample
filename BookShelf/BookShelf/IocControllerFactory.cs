using System;
using System.Diagnostics;
using System.Web.Mvc;
using StructureMap;

namespace BookShelf
{
    public class IocControllerFactory : DefaultControllerFactory 
    {
        [DebuggerStepThrough]
        protected override IController GetControllerInstance(Type controllerType)
        {
            try
            {
                return ObjectFactory.GetInstance(controllerType) as Controller;
            }
            catch(StructureMapException)
            {
                Debug.WriteLine(ObjectFactory.WhatDoIHave());
                throw;
            }
        }
    }
}
