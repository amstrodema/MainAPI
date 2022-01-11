using MainAPI.Data.Interface;
using MainAPI.Models;
using MainAPI.Models.DarlosValley;
using MainAPI.Models.ViewModel.DarlosValley;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainAPI.Business.DarlosValley
{
    public class WorkBusiness
    {
        private readonly IUnitOfWork _unitOfWork;

        public WorkBusiness(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseMessage<WorkVM>> GetWorks()
        {
            ResponseMessage<WorkVM> responseMessage = new ResponseMessage<WorkVM>();
            try
            {
                WorkVM workVM = new WorkVM();

                workVM.Works = (from work in await _unitOfWork.Works.GetAll()
                                select new Work()
                                {
                                    ID = work.ID,
                                    Image = work.Image,
                                    Title = work.Title.Length > 20 ? work.Title.Substring(0, 17).Trim() + "..." : work.Title,
                                    Stars = work.Stars,
                                    Price = work.Price,
                                    Description = work.Description.Length > 47 ? work.Description.Substring(0, 47).Trim() + "..." : work.Description
                                }).ToList();

                workVM.Images = await _unitOfWork.ImageSets.GetImageWithLocation("Graphics");

                responseMessage.Data = workVM;

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
        public async Task<ResponseMessage<List<Work>>> GetWorks_Limited()
        {
            ResponseMessage<List<Work>> responseMessage = new ResponseMessage<List<Work>>();
            try
            {
                responseMessage.Data = (List<Work>)await _unitOfWork.Works.GetSelected();
                responseMessage.Message = "Request Successful";
                responseMessage.StatusCode = 200;
            }
            catch (Exception)
            {
                responseMessage.Data = default;
                responseMessage.Message = "No Data";
                responseMessage.StatusCode = 201;
            }
            //responseMessage.Message = "Error occurred!";
            // responseMessage.StatusCode = 203;   responseMessage.Data = default;

            //var res = await _unitOfWork.Works.GetAll();
            //if (res.Count > 4)
            //{
            //    Random ran = new Random();
            //    List<int> keeper = new List<int>();
            //    List<Work> Response = new List<Work>();
            //    while (keeper.Count < 4)
            //    {
            //        int numb = ran.Next(0, res.Count);
            //        if (!keeper.Contains(numb))
            //        {
            //            keeper.Add(numb);
            //            Response.Add(res[numb]);
            //        }
            //    }
            //    try
            //    {
            //        for (int i = 0; i < 3; i++)
            //        {
            //            Response[i].isPick = true;
            //            responseMessage.Message = "Request Successful";
            //            responseMessage.StatusCode = 200;
            //            responseMessage.Data = Response;
            //        }
            //    }
            //    catch (Exception)
            //    {
            //    }
            //}
            //try
            //{
            //    for (int i = 0; i < 3; i++)
            //    {
            //        res[i].isPick = true;
            //    }
            //    responseMessage.Message = "Request Successful";
            //    responseMessage.StatusCode = 200;
            //    responseMessage.Data = res;
            //}
            //catch (Exception)
            //{
            //    responseMessage.Message = "Error occurred!";
            //     responseMessage.StatusCode = 203;   responseMessage.Data = default;
            //}

            return responseMessage;
        }
        public async Task<ResponseMessage<Work>> GetWorkByID(Guid id, string flag)
        {
            ResponseMessage<Work> responseMessage = new ResponseMessage<Work>();
            try
            {
                Work work = await _unitOfWork.Works.Find(id);

                if (flag != "Admin")
                {
                    await IncreaseView(work);
                }
                responseMessage.Data = work;
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
        private async Task<ResponseMessage<Work>> IncreaseView(Work work)
        {
            work.Views += 1;
            return await Update(work);
        }

        public async Task<ResponseMessage<Work>> Create(Work work)
        {
            ResponseMessage<Work> responseMessage = new ResponseMessage<Work>();
            try
            {
                work.ID = Guid.NewGuid();
                work.Date = DateTime.Now;
               await  _unitOfWork.Works.Create(work);
                if (await _unitOfWork.Commit() > 0)
                {
                    responseMessage.Message = "Request Successful";
                    responseMessage.StatusCode = 200;
                }
                else
                {
                    responseMessage.Message = "Request not Successful";
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

        public async Task<ResponseMessage<Work>> Update(Work work)
        {
            ResponseMessage<Work> responseMessage = new ResponseMessage<Work>();
            try
            {
                _unitOfWork.Works.Update(work);
                if (await _unitOfWork.Commit() > 0)
                {
                    responseMessage.Message = "Request Successful";
                    responseMessage.StatusCode = 200;
                }
                else
                {
                    responseMessage.Message = "Request not Successful";
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
        public async Task<ResponseMessage<Work>> Like(Guid id)
        {
            var entity = await GetWorkByID(id, "Admin");
            entity.Data.Likes += 1;
            return await Update(entity.Data);
        }

        public async Task<ResponseMessage<Work>> Delete(Guid id)
        {
            ResponseMessage<Work> responseMessage = new ResponseMessage<Work>();
            try
            {
                var entity = await GetWorkByID(id, "Admin");
                _unitOfWork.Works.Delete(entity.Data);

                if (await _unitOfWork.Commit() > 0)
                {
                    responseMessage.Message = "Request Successful";
                    responseMessage.StatusCode = 200;
                }
                else
                {
                    responseMessage.Message = "Request not Successful";
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
    }
}
