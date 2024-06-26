﻿using Castle.DynamicProxy;
using Chinook_Backend.CrossCuttingConcerns.Validation.FluentValidation;
using Chinook_Backend.Utilities.Interceptors;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chinook_Backend.Aspects.Validation
{
	public class ValidationAspect : MethodInterception
	{
		private Type _validatorType;
		public ValidationAspect(Type validatorType)
		{
			if (!typeof(IValidator).IsAssignableFrom(validatorType))
			{
				throw new System.Exception($"{validatorType.Name} is not found");
			}
			_validatorType = validatorType;
		}

		public override void OnBefore(IInvocation invocation)
		{
			var validator = (IValidator)Activator.CreateInstance(_validatorType);
			var entityType = _validatorType.BaseType.GetGenericArguments()[0];
			var entities = invocation.Arguments.Where(t => t.GetType() == entityType);

			foreach (var entity in entities)
			{
				ValidationTool.Validate(validator, entity);
			}
		}
	}
}
