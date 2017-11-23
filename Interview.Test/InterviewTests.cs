using System;
using Interview.Objects;
using Interview.Repositories;
using Interview;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace Interview.Test
{
	[TestClass]
	public class InterviewTests
	{
		[TestMethod]
		public void AddNewItemToStoreable()
		{
			IStoreable addStorable = new Storable();

			addStorable.Id = 1;
			RepositoryImplementation<IStoreable> ri = new RepositoryImplementation<IStoreable>();
			ri.Save(addStorable);
			Assert.IsTrue(1==(int)addStorable.Id);
			IStoreable retStorable = ri.FindById(addStorable.Id);
			Assert.IsTrue(retStorable.Id == addStorable.Id);


		}
		[TestMethod]
		[ExpectedException(typeof(ArgumentException),"The Storable Item already exists.")]
		public void AddExistingItemToStoreable()
		{
			IStoreable addStorable = new Storable();

			addStorable.Id = 1;
			RepositoryImplementation<IStoreable> ri = new RepositoryImplementation<IStoreable>();
			ri.Save(addStorable);
			ri.Save(addStorable);
		}

		[TestMethod]
		public void GetStorableItemByValidId()
		{
			IStoreable addStorable = new Storable();

			addStorable.Id = 1;
			RepositoryImplementation<IStoreable> ri = new RepositoryImplementation<IStoreable>();
			ri.Save(addStorable);
			addStorable.Id = 2;
			ri.Save(addStorable);
			addStorable.Id = 3;
			ri.Save(addStorable);

			IStoreable retVal = ri.FindById(3);
			Assert.IsTrue((int)retVal.Id == 3);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentException), "The Storable Item does not exist.")]
		public void GetStorableItemByInvalidId()
		{
			IStoreable addStorable = new Storable();

			addStorable.Id = 1;
			RepositoryImplementation<IStoreable> ri = new RepositoryImplementation<IStoreable>();
			ri.Save(addStorable);
			addStorable.Id = 2;
			ri.Save(addStorable);
			addStorable.Id = 3;
			ri.Save(addStorable);

			IStoreable retVal = ri.FindById(4);
			Assert.IsTrue((int)retVal.Id == 4);
		}

		[TestMethod]
		public void DeleteStorableItemByExistingId()
		{
			IStoreable addStorable = new Storable();

			addStorable.Id = 1;
			RepositoryImplementation<IStoreable> ri = new RepositoryImplementation<IStoreable>();
			ri.Save(addStorable);
			addStorable.Id = 2;
			ri.Save(addStorable);
			addStorable.Id = 3;
			ri.Save(addStorable);

			List<IStoreable> preDeleteCount = ri.All().ToList();

			ri.Delete(3);

			List<IStoreable> postDeleteCount = ri.All().ToList();

			Assert.IsTrue(preDeleteCount.Count == (postDeleteCount.Count + 1));

		}

		[TestMethod]
		public void DeleteStorableItemByInvalidIdNoDeleteionTalkesPlaceNoErrors()
		{
			IStoreable addStorable = new Storable();

			addStorable.Id = 1;
			RepositoryImplementation<IStoreable> ri = new RepositoryImplementation<IStoreable>();
			ri.Save(addStorable);
			addStorable.Id = 2;
			ri.Save(addStorable);
			addStorable.Id = 3;
			ri.Save(addStorable);

			List<IStoreable> preDeleteCount = ri.All().ToList();

			ri.Delete(4);

			List<IStoreable> postDeleteCount = ri.All().ToList();

			Assert.IsTrue(preDeleteCount.Count == (postDeleteCount.Count));

		}

		[TestMethod]
		public void GetAllStorableItem()
		{
			IStoreable addStorable = new Storable();

			addStorable.Id = 1;
			RepositoryImplementation<IStoreable> ri = new RepositoryImplementation<IStoreable>();
			ri.Save(addStorable);
			addStorable.Id = 2;
			ri.Save(addStorable);
			addStorable.Id = 3;
			ri.Save(addStorable);

			List<IStoreable> allStore = ri.All().ToList();

			Assert.IsTrue(allStore.Count == 3);

		}

	}
}
