﻿using System;
using System.Diagnostics;
using System.Linq;
using NUnit.Framework;
using Tests.DataClasses;
using Tests.DataClasses.Concrete;
using Tests.Helpers;

namespace Tests.UnitTests.Group80Performance
{
    class Perf04EfPostAsync
    {

        [TestFixtureSetUp]
        public void SetUpFixture()
        {
            using (var db = new SampleWebAppDb())
            {
                DataLayerInitialise.InitialiseThis();
                var filepath = TestFileHelpers.GetTestFileFilePath("DbContentSimple.xml");
                DataLayerInitialise.ResetDatabaseToTestData(db, filepath);
            }
        }


        [Test]
        public async void Check05ListEfDirectOk()
        {
            using (var db = new SampleWebAppDb())
            {
                //SETUP
                var timer = new Stopwatch();
                timer.Start();

                //ATTEMPT
                await db.ListEfDirectAsync<Post>(0);
                timer.Stop();

                //VERIFY
                Console.WriteLine("Ef operation took {0} ms",timer.ElapsedMilliseconds);
            }
        }

        [Test]
        public async void Check06ListEfViaDtoOk()
        {
            using (var db = new SampleWebAppDb())
            {
                //SETUP
                var timer = new Stopwatch();
                timer.Start();

                //ATTEMPT
                await db.ListPostEfViaDtoAsync(0);
                timer.Stop();

                //VERIFY
                Console.WriteLine("Ef operation took {0} ms", timer.ElapsedMilliseconds);
            }
        }

        [Test]
        public async void Check10CreateEfDirectOk()
        {
            using (var db = new SampleWebAppDb())
            {
                //SETUP
                var timer = new Stopwatch();
                timer.Start();

                //ATTEMPT
                await db.CreatePostEfDirectAsync(0);
                timer.Stop();

                //VERIFY
                Console.WriteLine("Ef operation took {0} ms", timer.ElapsedMilliseconds);
            }
        }


        [Test]
        public async void Check11UpdateEfDirectOk()
        {
            int postId;
            using (var db = new SampleWebAppDb())
                postId = db.Posts.AsNoTracking().First().PostId;

            using (var db = new SampleWebAppDb())
            {
                //SETUP
                var timer = new Stopwatch();
                timer.Start();

                //ATTEMPT
                await db.UpdatePostEfDirectAsync(postId);
                timer.Stop();

                //VERIFY
                Console.WriteLine("Ef operation took {0} ms", timer.ElapsedMilliseconds);
            }
        }

        [Test]
        public async void Check12DeleteEfDirectOk()
        {
            int postId;
            using (var db = new SampleWebAppDb())
                postId = db.Posts.AsNoTracking().First().PostId;

            using (var db = new SampleWebAppDb())
            {
                //SETUP
                var timer = new Stopwatch();
                timer.Start();

                //ATTEMPT
                await db.DeletePostEfDirectAsync(postId);
                timer.Stop();

                //VERIFY
                Console.WriteLine("Ef operation took {0} ms", timer.ElapsedMilliseconds);
            }
        }

    }
}
