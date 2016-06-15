using System;
using FluentAssertions;
using Newtonsoft.Json.Linq;
using OpenMagic.ErrorTracker.Core.Serialization;
using TechTalk.SpecFlow;

namespace OpenMagic.ErrorTracker.Core.Specifications.Features.Serialization.Steps
{
    [Binding]
    public class SerializerSteps
    {
        private readonly ISerializer _serializer;
        private string _contentType;
        private string _json;
        private object _obj;
        private Type _type;
        private object _value;

        public SerializerSteps()
        {
            _serializer = new Serializer();
        }

        [Given(@"value parameters is new Exception\(""(.*)""\)")]
        public void GivenValueParametersIsNewException(string errorMessage)
        {
            _value = new Exception(errorMessage);
        }

        [When(@"I call Serializer\.ToJson\(object value\)")]
        public void WhenICallSerializer_ToJsonObjectValue()
        {
            _json = _serializer.ToJson(_value);
        }

        [When(@"I call Serializer\.ToJson\(object value, out string contentType\)")]
        public void WhenICallSerializer_ToJsonObjectValueOutStringContentType()
        {
            _json = _serializer.ToJson(_value, out _contentType);
        }

        [Then(@"the result should be")]
        public void ThenTheResultShouldBe(string expected)
        {
            _json.Should().Be(expected);
        }

        [Then(@"contentType should be '(.*)'")]
        public void ThenContentTypeShouldBe(string expected)
        {
            _contentType.Should().Be(expected);
        }

        [Given(@"json is")]
        public void GivenJsonIs(string json)
        {
            _json = json;
        }

        [Given(@"contentType is '(.*)'")]
        public void GivenContentTypeIs(string contentType)
        {
            _contentType = contentType;
        }

        [When(@"I call Serializer\.FromJson\(string json\)")]
        public void WhenICallSerializer_FromJsonStringJson()
        {
            _obj = _serializer.FromJson(_json);
        }

        [When(@"I call Serializer\.FromJson\(string json, Type type\)")]
        public void WhenICallSerializer_FromJsonStringJsonTypeType()
        {
            _obj = _serializer.FromJson(_json, _type);
        }

        [When(@"I call Serializer\.FromJson\(string json, string contentType\)")]
        public void WhenICallSerializer_FromJsonStringJsonStringContentType()
        {
            _obj = _serializer.FromJson(_json, _contentType);
        }

        [Then(@"the result should be new Exception\(""(.*)""\)")]
        public void ThenTheResultShouldBeNewException(string errorMessage)
        {
            var expected = new Exception(errorMessage);
            var actual = (Exception)_obj;

            actual.ShouldBeEquivalentTo(expected);
        }

        [Then(@"the result should be type JObject")]
        public void ThenTheResultShouldBeTypeJObject()
        {
            _obj.Should().BeOfType<JObject>();
        }

        [When(@"the result is cast to Exception")]
        public void WhenTheResultIsCastToException()
        {
            _obj.Should().BeOfType<JObject>("because that's what is required before casting to Exception");
            _obj = ((JObject)_obj).ToObject<Exception>();
        }

        [When(@"I call Serializer\.FromJson\<Exception\>\(string json\)")]
        public void WhenICallSerializer_FromJsonGenericTypeStringJson()
        {
            _obj = _serializer.FromJson<Exception>(_json);
        }

        [Given(@"type is 'Exception'")]
        public void GivenTypeIsException()
        {
            _type = typeof(Exception);
        }

        [Then(@"the result should be type Exception")]
        public void ThenTheResultShouldBeTypeException()
        {
            _obj.Should().BeOfType<Exception>();
        }
    }
}