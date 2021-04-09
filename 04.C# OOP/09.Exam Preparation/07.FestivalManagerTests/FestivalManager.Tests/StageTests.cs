namespace FestivalManager.Tests
{
    using NUnit.Framework;
	using FestivalManager.Entities;
    using System;

    [TestFixture]
	public class StageTests
    {
		private Stage testStage;
		private Song testSong;
		private Performer testPerformer;

		[SetUp]
		public void SetUp()
        {
			testStage = new Stage();
			testSong = new Song("test", new TimeSpan(0,3,20));
			testPerformer = new Performer("tester","testov", 20);
        }

		[Test]
	    public void Create_Collection_Created()
	    {
			Assert.AreEqual(0, testStage.Performers.Count);
		}

		[Test]
		public void AddPerformer_IfNull_Throw()
        {
			Assert.Throws<ArgumentNullException>(() => testStage.AddPerformer(null));
        }
		[Test]
		public void AddPerformer_InvalidAge_Throw()
		{
			Assert.Throws<ArgumentException>(() => testStage.AddPerformer(new Performer("test","tester", 17)), "You can only add performers that are at least 18.");
		}
		[Test]
		public void AddPerformer_Works()
		{
			testStage.AddPerformer(testPerformer);

			Assert.AreEqual(1, testStage.Performers.Count);
		}
		[Test]
		public void AddSong_NullSong_Throw()
        {
			Assert.Throws<ArgumentNullException>(() => testStage.AddSong(null));
        }
		[Test]
		public void AddSong_DurationUnderMinute_Throw()
		{
			Assert.Throws<ArgumentException>(() => testStage.AddSong(new Song("test", new TimeSpan(0,0,20))), "You can only add songs that are longer than 1 minute.");
		}
		[Test]
		public void AddSong_Works_AddSongToPerformer_Works()
		{
			testStage.AddPerformer(testPerformer);
			testStage.AddSong(testSong);

			string expected = $"{testSong} will be performed by {testPerformer}";

			Assert.AreEqual(expected, testStage.AddSongToPerformer(testSong.Name, testPerformer.FullName));
		}
		[Test]
		public void AddSongToPerf_NotExistPerf_Throws()
		{
			Assert.Throws<ArgumentException>(() => testStage.AddSongToPerformer(testSong.Name, testPerformer.FullName));
		}
		[Test]
		public void AddSongToPerf_NotExistSong_Throws()
		{
			testStage.AddPerformer(testPerformer);

			Assert.Throws<ArgumentException>(() => testStage.AddSongToPerformer(testSong.Name, testPerformer.FullName));
		}
		[Test]
		public void Play_Works()
        {
			testStage.AddPerformer(testPerformer);
			testStage.AddSong(testSong);
			testStage.AddSongToPerformer(testSong.Name, testPerformer.FullName);

			string expected = $"{1} performers played {1} songs";

			Assert.AreEqual(expected, testStage.Play());

		}
	}
}