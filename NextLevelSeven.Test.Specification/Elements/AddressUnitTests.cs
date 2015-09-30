﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using NextLevelSeven.Core;
using NextLevelSeven.Specification;
using NextLevelSeven.Specification.Elements;
using NextLevelSeven.Test.Testing;

namespace NextLevelSeven.Test.Specification.Elements
{
    [TestClass]
    public class AddressUnitTests : SpecificationTestFixture
    {
        private IAddress _address;
        private string _addressType;
        private string _city;
        private string _country;
        private string _message;
        private string _otherDesignation;
        private string _otherGeographicDesignation;
        private string _stateOrProvince;
        private string _streetAddress;
        private string _zipOrPostalCode;

        [TestInitialize]
        public void Initialize()
        {
            _streetAddress = Mock.String();
            _otherDesignation = Mock.String();
            _city = Mock.String();
            _stateOrProvince = Mock.String();
            _zipOrPostalCode = Mock.String();
            _country = Mock.String();
            _addressType = "C";
            _otherGeographicDesignation = Mock.String();
            _message = string.Format("MSH|^~\\&|{0}^{1}^{2}^{3}^{4}^{5}^{6}^{7}|{8}",
                _streetAddress, _otherDesignation, _city, _stateOrProvince,
                _zipOrPostalCode, _country, _addressType, _otherGeographicDesignation,
                Mock.String());
            _address = Message.Parse(_message)[1][3][1].AsAddress();
        }

        [TestMethod]
        public void Address_Validate_Fails_WithInvalidAddressType()
        {
            _address.AddressTypeData = "\x1";
            AssertAction.Throws<ValidationException>(_address.Validate, "Validation must fail with invalid address type.");
        }

        [TestMethod]
        public void Address_Validate_Succeeds_WithValidAddressType()
        {
            _address.Validate();
        }

        [TestMethod]
        public void Address_Validate_Succeeds_WithNullAddressType()
        {
            _address.AddressTypeData = null;
            _address.Validate();
        }

        [TestMethod]
        public void Address_Parses_StreetAddress()
        {
            Assert.AreEqual(_streetAddress, _address.StreetAddress);
        }

        [TestMethod]
        public void Address_Parses_OtherDesignation()
        {
            Assert.AreEqual(_otherDesignation, _address.OtherDesignation);
        }

        [TestMethod]
        public void Address_Parses_City()
        {
            Assert.AreEqual(_city, _address.City);
        }

        [TestMethod]
        public void Address_Parses_State()
        {
            Assert.AreEqual(_stateOrProvince, _address.StateOrProvince);
        }

        [TestMethod]
        public void Address_Parses_Zip()
        {
            Assert.AreEqual(_zipOrPostalCode, _address.ZipOrPostalCode);
        }

        [TestMethod]
        public void Address_Parses_Country()
        {
            Assert.AreEqual(_country, _address.Country);
        }

        [TestMethod]
        public void Address_Parses_AddressType()
        {
            Assert.AreEqual(AddressType.CurrentOrTemporary, _address.AddressType);
        }

        [TestMethod]
        public void Address_Parses_AddressTypeData()
        {
            Assert.AreEqual(_addressType, _address.AddressTypeData);
        }

        [TestMethod]
        public void Address_Parses_OtherGeographicDesignation()
        {
            Assert.AreEqual(_otherGeographicDesignation, _address.OtherGeographicDesignation);
        }

        [TestMethod]
        public void Address_Sets_StreetAddress()
        {
            var value = Mock.String();
            _address.StreetAddress = value;
            Assert.AreEqual(value, _address.StreetAddress);
        }

        [TestMethod]
        public void Address_Sets_OtherDesignation()
        {
            var value = Mock.String();
            _address.OtherDesignation = value;
            Assert.AreEqual(value, _address.OtherDesignation);
        }

        [TestMethod]
        public void Address_Sets_City()
        {
            var value = Mock.String();
            _address.City = value;
            Assert.AreEqual(value, _address.City);
        }

        [TestMethod]
        public void Address_Sets_State()
        {
            var value = Mock.String();
            _address.StateOrProvince = value;
            Assert.AreEqual(value, _address.StateOrProvince);
        }

        [TestMethod]
        public void Address_Sets_Zip()
        {
            var value = Mock.String();
            _address.ZipOrPostalCode = value;
            Assert.AreEqual(value, _address.ZipOrPostalCode);
        }

        [TestMethod]
        public void Address_Sets_Country()
        {
            var value = Mock.String();
            _address.Country = value;
            Assert.AreEqual(value, _address.Country);
        }

        [TestMethod]
        public void Address_Sets_AddressType()
        {
            _address.AddressType = AddressType.Office;
            Assert.AreEqual(AddressType.Office, _address.AddressType);
        }

        [TestMethod]
        public void Address_Sets_AddressTypeData()
        {
            _address.AddressTypeData = "O";
            Assert.AreEqual("O", _address.AddressTypeData);
        }

        [TestMethod]
        public void Address_Sets_OtherGeographicDesignation()
        {
            var value = Mock.String();
            _address.OtherGeographicDesignation = value;
            Assert.AreEqual(value, _address.OtherGeographicDesignation);
        }
    }
}