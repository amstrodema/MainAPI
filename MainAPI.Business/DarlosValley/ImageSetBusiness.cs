using MainAPI.Data.Interface;
using MainAPI.Models;
using MainAPI.Models.DarlosValley;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainAPI.Business.DarlosValley
{
    public class ImageSetBusiness
    {
        private readonly IUnitOfWork _unitOfWork;

        public ImageSetBusiness(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ResponseMessage<ImageSet>> Create(ImageSet imageSet)
        {
            ResponseMessage<ImageSet> responseMessage = new ResponseMessage<ImageSet>();
            try
            {
                imageSet.ID = Guid.NewGuid();
                //  blog.UserID = (Guid)HttpContext.Current.Session["UserID"];
                await _unitOfWork.ImageSets.Create(imageSet);

                if (await _unitOfWork.Commit() > 0)
                {
                    responseMessage.Message = "Request Successful";
                    responseMessage.StatusCode = 200;
                }
                else
                {
                    responseMessage.Message = "Request Unsuccessful";
                    responseMessage.StatusCode = 201; responseMessage.Data = default;
                }
                return responseMessage;
            }
            catch (Exception)
            {
                responseMessage.Message = "Something went wrong";
                responseMessage.StatusCode = 203; responseMessage.Data = default;
            }

            return responseMessage;
        }

        public async Task<ResponseMessage<IEnumerable<ImageSet>>> Get()
        {
            ResponseMessage<IEnumerable<ImageSet>> responseMessage = new ResponseMessage<IEnumerable<ImageSet>>();
            responseMessage.Data = await _unitOfWork.ImageSets.GetAll();
            return responseMessage;
        }
        public async Task<ResponseMessage<IEnumerable<ImageSet>>> GetByLocation(string location)
        {
            ResponseMessage<IEnumerable<ImageSet>> responseMessage = new ResponseMessage<IEnumerable<ImageSet>>();
            responseMessage.Data = await _unitOfWork.ImageSets.GetImageWithLocation(location);
            return responseMessage;
        }
        public async Task<ResponseMessage<IEnumerable<ImageSet>>> GetImageWithLocationByEditor(string location)
        {
            ResponseMessage<IEnumerable<ImageSet>> responseMessage = new ResponseMessage<IEnumerable<ImageSet>>();
            responseMessage.Data = await _unitOfWork.ImageSets.GetImageWithLocationByEditor(location);
            return responseMessage;
        }
        public async Task<ResponseMessage<ImageSet>> GetByID(Guid imgID)
        {
            ResponseMessage<ImageSet> responseMessage = new ResponseMessage<ImageSet>();
            responseMessage.Data = await _unitOfWork.ImageSets.Find(imgID);
            return responseMessage;
        }


        public async Task<ResponseMessage<ImageSet>> Update(ImageSet imageSet)
        {
            ResponseMessage<ImageSet> responseMessage = new ResponseMessage<ImageSet>();
            try
            {
                _unitOfWork.ImageSets.Update(imageSet);

                if (await _unitOfWork.Commit() > 0)
                {
                    responseMessage.Message = "Request Successful";
                    responseMessage.StatusCode = 200;
                }
                else
                {
                    responseMessage.Message = "Request Unsuccessful";
                    responseMessage.StatusCode = 201; responseMessage.Data = default;
                }
            }
            catch (Exception)
            {
                responseMessage.Message = "Something went wrong";
                responseMessage.StatusCode = 203; responseMessage.Data = default;
            }

            return responseMessage;
        }

        public async Task<ResponseMessage<ImageSet>> Delete(Guid id)
        {
            ResponseMessage<ImageSet> responseMessage = new ResponseMessage<ImageSet>();

            var entity = await GetByID(id);
            _unitOfWork.ImageSets.Delete(entity.Data);

            if (await _unitOfWork.Commit() > 0)
            {
                responseMessage.Message = "Request Successful";
                responseMessage.StatusCode = 200;
            }
            else
            {
                responseMessage.Message = "Request Unsuccessful";
                responseMessage.StatusCode = 201; responseMessage.Data = default;
            }
            return responseMessage;
        }
    }
}
