// Use this file for your unit tests.
// When you are ready to submit, REMOVE all using statements to Festival Manager (entities/controllers/etc)
// Test ONLY the Stage class. 
namespace FestivalManager.Tests
{
    //using FestivalManager.Entities;
    using NUnit.Framework;
    using System;
    using System.Linq;

    [TestFixture]
	public class StageTests
    {
        [Test]
        public void ValidateNullValue_Throws()
        {
            Stage stage = new Stage();
            Assert.Throws<ArgumentNullException>(() => stage.AddPerformer(null));
        }
        [Test]
        public void AddPerformer_ThrowsFor_UnderAge()
        {
            Stage stage = new Stage();
            Performer performer = new Performer("first","last",7);
            Assert.Throws<ArgumentException>(()=> stage.AddPerformer(performer));
        }
        [Test]
        public void AddPerformer_Valid()
        {
            Stage stage = new Stage();
            Performer performer = new Performer("first","last",99);
            stage.AddPerformer(performer);
            Performer actual = stage.Performers.First();
            Assert.AreEqual(1,stage.Performers.Count);
            Assert.AreSame(performer,actual);
        }
        [Test]
        public void AddSong_ThrowsFor_LessThan_Minute()
        {
            Stage stage = new Stage();
            TimeSpan span = new TimeSpan(0,0,5);
            Song song = new Song("song",span);
            Assert.Throws<ArgumentException>(()=>stage.AddSong(song));
        }
        [Test]
        public void AddSong_Valid()
        {
            Stage stage = new Stage();
            TimeSpan span = new TimeSpan(0,3,0);
            Song song = new Song("song",span);
            Performer performer = new Performer("first","last",99);
            string expected = "song (03:00) will be performed by first last";
            stage.AddSong(song);
            stage.AddPerformer(performer);
            string actual = stage.AddSongToPerformer("song","first last");
            Assert.AreEqual(expected,actual);
        }
        [Test]
        public void Play_Valid()
        {
            Stage stage = new Stage();
            Song song = new Song("song",new TimeSpan(0,2,0));
            Song song1 = new Song("song1",new TimeSpan(0,3,0));
            Song song2 = new Song("song2",new TimeSpan(0,4,0));
            Performer performer = new Performer("first","last",99);
            Performer performer1 = new Performer("first1","last1",98);
            Performer performer2 = new Performer("first2","last2",97);
            string expected = "3 performers played 3 songs";
            stage.AddSong(song);
            stage.AddSong(song1);
            stage.AddSong(song2);
            stage.AddPerformer(performer);
            stage.AddPerformer(performer1);
            stage.AddPerformer(performer2);
            stage.AddSongToPerformer(song.Name,performer.FullName);
            stage.AddSongToPerformer(song1.Name,performer1.FullName);
            stage.AddSongToPerformer(song2.Name,performer2.FullName);
            string actual = stage.Play();
            Assert.AreEqual(expected,actual);
        }
        [Test]
	    public void _()
	    {

		}
	}
}