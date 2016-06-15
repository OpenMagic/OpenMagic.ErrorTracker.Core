Feature: Serializer
	In order to have consistent serialization across ErrorTracker project
	I want a single serializer

Scenario: ToJson(object value)
	Given value parameters is new Exception("dummy exception")
	When I call Serializer.ToJson(object value)
	Then the result should be
        """
        {"ClassName":"System.Exception","Message":"dummy exception","Data":null,"InnerException":null,"HelpURL":null,"StackTraceString":null,"RemoteStackTraceString":null,"RemoteStackIndex":0,"ExceptionMethod":null,"HResult":-2146233088,"Source":null,"WatsonBuckets":null}
        """

Scenario: ToJson(object value, out string contentType)
	Given value parameters is new Exception("dummy exception")
	When I call Serializer.ToJson(object value, out string contentType)
	Then the result should be
        """
        {"ClassName":"System.Exception","Message":"dummy exception","Data":null,"InnerException":null,"HelpURL":null,"StackTraceString":null,"RemoteStackTraceString":null,"RemoteStackIndex":0,"ExceptionMethod":null,"HResult":-2146233088,"Source":null,"WatsonBuckets":null}
        """
    And contentType should be 'application/json; type=System.Exception'

Scenario: FromJson(string json)
    Given json is
        """
        {"ClassName":"System.Exception","Message":"dummy exception","Data":null,"InnerException":null,"HelpURL":null,"StackTraceString":null,"RemoteStackTraceString":null,"RemoteStackIndex":0,"ExceptionMethod":null,"HResult":-2146233088,"Source":null,"WatsonBuckets":null}
        """
	When I call Serializer.FromJson(string json)
    Then the result should be type JObject
    When the result is cast to Exception
    Then the result should be new Exception("dummy exception")

Scenario: FromJson(string json, Type type)
    Given json is
        """
        {"ClassName":"System.Exception","Message":"dummy exception","Data":null,"InnerException":null,"HelpURL":null,"StackTraceString":null,"RemoteStackTraceString":null,"RemoteStackIndex":0,"ExceptionMethod":null,"HResult":-2146233088,"Source":null,"WatsonBuckets":null}
        """
    And type is 'Exception'
	When I call Serializer.FromJson(string json, Type type)
    Then the result should be type Exception
    Then the result should be new Exception("dummy exception")

Scenario: FromJson(string json, string contentType)
    Given json is
        """
        {"ClassName":"System.Exception","Message":"dummy exception","Data":null,"InnerException":null,"HelpURL":null,"StackTraceString":null,"RemoteStackTraceString":null,"RemoteStackIndex":0,"ExceptionMethod":null,"HResult":-2146233088,"Source":null,"WatsonBuckets":null}
        """
    And contentType is 'application/json; type=System.Exception'
	When I call Serializer.FromJson(string json, string contentType)
    Then the result should be type Exception
    Then the result should be new Exception("dummy exception")

Scenario: FromJson<T>(string json)
    Given json is
        """
        {"ClassName":"System.Exception","Message":"dummy exception","Data":null,"InnerException":null,"HelpURL":null,"StackTraceString":null,"RemoteStackTraceString":null,"RemoteStackIndex":0,"ExceptionMethod":null,"HResult":-2146233088,"Source":null,"WatsonBuckets":null}
        """
	When I call Serializer.FromJson<Exception>(string json)
    Then the result should be type Exception
    Then the result should be new Exception("dummy exception")
