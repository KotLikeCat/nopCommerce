﻿using FluentValidation.TestHelper;
using Moq;
using Nop.Data;
using Nop.Web.Areas.Admin.Models.Catalog;
using Nop.Web.Areas.Admin.Validators.Catalog;
using Nop.Web.MVC.Tests.Public.Validators;
using NUnit.Framework;

namespace Nop.Web.MVC.Tests.Admin.Validators.Catalog
{
    [TestFixture]
    public class ManufacturerValidatorTests : BaseValidatorTests
    {
        private ManufacturerValidator _validator;
        private Mock<INopDataProvider> _dataProvider;

        [SetUp]
        public new void Setup()
        {
            _dataProvider = new Mock<INopDataProvider>();
            _validator = new ManufacturerValidator(_dataProvider.Object, _localizationService);
        }

        [Test]
        public void Should_have_error_when_pageSizeOptions_has_duplicate_items()
        {
            var model = new ManufacturerModel
            {
                PageSizeOptions = "1, 2, 3, 5, 2"
            };
            _validator.ShouldHaveValidationErrorFor(x => x.PageSizeOptions, model);
        }

        [Test]
        public void Should_not_have_error_when_pageSizeOptions_has_not_duplicate_items()
        {
            var model = new ManufacturerModel
            {
                PageSizeOptions = "1, 2, 3, 5, 9"
            };
            _validator.ShouldNotHaveValidationErrorFor(x => x.PageSizeOptions, model);
        }

        [Test]
        public void Should_not_have_error_when_pageSizeOptions_is_null_or_empty()
        {
            var model = new ManufacturerModel
            {
                PageSizeOptions = null
            };
            _validator.ShouldNotHaveValidationErrorFor(x => x.PageSizeOptions, model);
            model.PageSizeOptions = "";
            _validator.ShouldNotHaveValidationErrorFor(x => x.PageSizeOptions, model);
        }
    }
}