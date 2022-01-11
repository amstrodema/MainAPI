using MainAPI.Data.Interface;
using MainAPI.Models;
using MainAPI.Models.DarlosValley;
using MainAPI.Models.ViewModel.DarlosValley;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MainAPI.Business.DarlosValley
{
    public class BlogBusiness
    {
        private readonly IUnitOfWork _unitOfWork;

        public BlogBusiness(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseMessage<List<Blog>>> GetBlogs()
        {
            ResponseMessage<List<Blog>> responseMessage = new ResponseMessage<List<Blog>>();
            try
            {
                responseMessage.Data = (from blog in await _unitOfWork.Blogs.GetAll()
                                       select new Blog()
                                       {
                                           ID = blog.ID,
                                           Image = blog.Image,
                                           Subject = blog.Subject.Length > 20 ? blog.Subject.Substring(0, 20).Trim() + "..." : blog.Subject,
                                           DatePosted = blog.DatePosted,
                                           View = blog.View,
                                           Post = blog.Post.Length > 47 ? blog.Post.Substring(0, 47).Trim() + "..." : blog.Post
                                       }).ToList();

                responseMessage.Message = "Request Successful";
                responseMessage.StatusCode = 200;
            }
            catch (Exception)
            {
                responseMessage.Message = "Error occurred!";
                 responseMessage.StatusCode = 203;   responseMessage.Data = default;
            }

            return responseMessage;
        }

        public async Task<ResponseMessage<List<Blog>>> GetBlogs_Limited()
        {
            ResponseMessage<List<Blog>> responseMessage = new ResponseMessage<List<Blog>>();

            try
            {
                responseMessage.Data = (List<Blog>) await _unitOfWork.Blogs.GetSelected();
                responseMessage.Message = "Request Successful";
                responseMessage.StatusCode = 200;
            }
            catch (Exception)
            {
                responseMessage.Data = default;
                responseMessage.Message = "No Data";
                responseMessage.StatusCode = 201;
            }
            //if (res.Count > 4)
            //{
            //    Random ran = new Random();
            //    List<int> keeper = new List<int>();
            //    List<Blog> Response = new List<Blog>();

            //    int numb = ran.Next(0, res.Count);
            //    while (keeper.Count <= 4)
            //    {
            //        if (numb == res.Count)
            //        {
            //            numb = 0;
            //        }

            //        if (!keeper.Contains(numb))
            //        {
            //            keeper.Add(numb);
            //            Response.Add(res[numb]);
            //        }

            //        numb++;
            //    }
            //    Response[0].isPick = true;

            //    responseMessage.Data = Response;
            //    responseMessage.Message = "Request Successful";
            //    responseMessage.StatusCode = 200;
            //    return responseMessage;
            //}
            //try
            //{
            //    res[0].isPick = true;
            //    responseMessage.Data = res;
            //    responseMessage.Message = "Request Successful";
            //    responseMessage.StatusCode = 200;
            //}
            //catch (Exception)
            //{
            //    responseMessage.Message = "No Data";
            //     responseMessage.StatusCode = 201;   responseMessage.Data = default;
            //}
            return responseMessage;
        }

        public async Task<ResponseMessage<Blog>> GetBlogByID(Guid id, string flag)
        {
            ResponseMessage<Blog> responseMessage = new ResponseMessage<Blog>();
            try
            {
                Blog blog = await _unitOfWork.Blogs.Find(id);
                if (flag != "Admin")
                {
                    await IncreaseView(blog);
                }

                responseMessage.Data = blog;
                responseMessage.Message = "Request Successful";
                responseMessage.StatusCode = 200;

                return responseMessage;
            }
            catch (Exception)
            {
                return null;
            }
        }
        private async Task<ResponseMessage<Blog>> IncreaseView(Blog blog)
        {
            blog.View += 1;
            return await Update(blog);
        }

        public async Task<ResponseMessage<Blog>> Create(Blog blog)
        {
            ResponseMessage<Blog> responseMessage = new ResponseMessage<Blog>();
            try
            {
                blog.DatePosted = DateTime.Now;
                blog.ID = Guid.NewGuid();
                //  blog.UserID = (Guid)HttpContext.Current.Session["UserID"];
                await _unitOfWork.Blogs.Create(blog);

                if (await _unitOfWork.Commit() > 0)
                {
                    responseMessage.Message = "Request Successful";
                    responseMessage.StatusCode = 200;
                }
                else
                {
                    responseMessage.Message = "Request Unsuccessful";
                     responseMessage.StatusCode = 201;   responseMessage.Data = default;
                }
                return responseMessage;
            }
            catch (Exception)
            {
                responseMessage.Message = "Something went wrong";
                 responseMessage.StatusCode = 203;   responseMessage.Data = default;
            }

            return responseMessage;
        }

        public async Task<ResponseMessage<Blog>> Update(Blog blog)
        {
            ResponseMessage<Blog> responseMessage = new ResponseMessage<Blog>();
            try
            {
                _unitOfWork.Blogs.Update(blog);

                if (await _unitOfWork.Commit() > 0)
                {
                    responseMessage.Message = "Request Successful";
                    responseMessage.StatusCode = 200;
                }
                else
                {
                    responseMessage.Message = "Request Unsuccessful";
                     responseMessage.StatusCode = 201;   responseMessage.Data = default;
                }
            }
            catch (Exception)
            {
                responseMessage.Message = "Something went wrong";
                 responseMessage.StatusCode = 203;   responseMessage.Data = default;
            }

            return responseMessage;
        }
        public async Task<ResponseMessage<Blog>> Like(Guid id)
        {
            ResponseMessage<Blog> responseMessage = new ResponseMessage<Blog>();
            try
            {
                var entity = await GetBlogByID(id, "Admin");
                entity.Data.Like += 1;
                return await Update(entity.Data);
            }
            catch (Exception)
            {
                responseMessage.Message = "Error Occurrred!";
                 responseMessage.StatusCode = 203;   responseMessage.Data = default;
            }
            return responseMessage;
        }

        public async Task<ResponseMessage<Blog>> Delete(Guid id)
        {
            ResponseMessage<Blog> responseMessage = new ResponseMessage<Blog>();

            var entity = await GetBlogByID(id, "Admin");
            _unitOfWork.Blogs.Delete(entity.Data);

            if (await _unitOfWork.Commit() > 0)
            {
                responseMessage.Message = "Request Successful";
                responseMessage.StatusCode = 200;
            }
            else
            {
                responseMessage.Message = "Request Unsuccessful";
                 responseMessage.StatusCode = 201;   responseMessage.Data = default;
            }
            return responseMessage;
        }

        public async Task<ResponseMessage<HomeVM>> GetHomeData()
        {

            ResponseMessage<HomeVM> responseMessage = new ResponseMessage<HomeVM>();
            try
            {
                HomeVM homeVM = new HomeVM();

                homeVM.Blogs = from blog in await _unitOfWork.Blogs.GetSelected()
                               select new Blog()
                               {
                                   ID = blog.ID,
                                   Image = blog.Image,
                                   Subject = blog.Subject.Length > 20 ? blog.Subject.Substring(0,20).Trim() + "..." : blog.Subject,
                                   DatePosted = blog.DatePosted,
                                   View = blog.View
                               };

                homeVM.Works = from work in await _unitOfWork.Works.GetSelected()
                               select new Work()
                               {
                                   ID = work.ID,
                                   Image = work.Image,
                                   Title = work.Title.Length > 20 ? work.Title.Substring(0, 17).Trim() + "..." : work.Title,
                                   Stars = work.Stars,
                                   Price = work.Price
                               };

                homeVM.Graphics = await _unitOfWork.ImageSets.GetImageWithLocationByEditor("Graphics");

                try
                {
                    homeVM.Headlines = from blog in await _unitOfWork.Blogs.GetAll()
                                       where blog.isHot
                                       select new Blog()
                                       {
                                           ID = blog.ID,
                                           Subject = blog.Subject
                                       };
                }
                catch (Exception)
                {
                }

                responseMessage.Data = homeVM;
            }
            catch (Exception)
            {
                responseMessage.Message = "Request Unsuccessful";
                responseMessage.StatusCode = 201; responseMessage.Data = default;
            }
           
            return responseMessage;
        }
    }
}