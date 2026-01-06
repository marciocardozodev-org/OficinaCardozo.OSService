using Xunit;

namespace OficinaCardozo.Tests.TestBase;

[CollectionDefinition("Integration Tests")]
public class IntegrationTestCollection : ICollectionFixture<IntegrationTestFixture>
{
}

public class IntegrationTestFixture
{
}