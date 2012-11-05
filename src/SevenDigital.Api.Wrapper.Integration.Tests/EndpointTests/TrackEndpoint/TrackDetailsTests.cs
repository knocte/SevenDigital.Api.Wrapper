﻿using NUnit.Framework;
using SevenDigital.Api.Schema.TrackEndpoint;
using SevenDigital.Api.Wrapper.Integration.Tests.EndpointTests.ArtistEndpoint;

namespace SevenDigital.Api.Wrapper.Integration.Tests.EndpointTests.TrackEndpoint
{
	[TestFixture]
	public class TrackDetailsTests
	{
		[Test]
		public void Can_hit_endpoint()
		{
			Track track = FluentApiFactory.CreateFluentApi<Track>()
				.ForTrackId(12345)
				.Please();

			Assert.That(track, Is.Not.Null);
			Assert.That(track.Title, Is.EqualTo("I Love You"));
			Assert.That(track.Artist.Name, Is.EqualTo("The Dandy Warhols"));
		}
	}
}