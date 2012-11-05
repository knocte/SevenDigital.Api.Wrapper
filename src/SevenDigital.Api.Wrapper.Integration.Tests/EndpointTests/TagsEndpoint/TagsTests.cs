﻿using System.Linq;
using NUnit.Framework;
using SevenDigital.Api.Schema.Tags;
using SevenDigital.Api.Wrapper.Integration.Tests.EndpointTests.ArtistEndpoint;

namespace SevenDigital.Api.Wrapper.Integration.Tests.EndpointTests.TagsEndpoint
{
	[TestFixture]
	public class TagsTests 
	{
		[Test]
		public void Can_hit_endpoint() 
		{
			Tags tags = FluentApiFactory.CreateFluentApi<Tags>()
				.Please();

			Assert.That(tags, Is.Not.Null);
			Assert.That(tags.TagList.Count, Is.GreaterThan(0));
			Assert.That(tags.TagList.FirstOrDefault().Id, Is.Not.Empty);
			Assert.That(tags.TagList.Where(x=>x.Id == "rock").FirstOrDefault().Text, Is.EqualTo("rock"));
		}

		[Test]
		public void Can_hit_endpoint_with_paging() 
		{
			Tags artistBrowse = FluentApiFactory.CreateFluentApi<Tags>()
				.WithParameter("page", "2")
				.WithParameter("pageSize", "20")
				.Please();

			Assert.That(artistBrowse, Is.Not.Null);
			Assert.That(artistBrowse.Page, Is.EqualTo(2));
			Assert.That(artistBrowse.PageSize, Is.EqualTo(20));
		}
	}
}