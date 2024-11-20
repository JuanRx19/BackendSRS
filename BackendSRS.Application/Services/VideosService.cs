using BackendSRS.Domain.Interfaces;
using BackendSRS.Domain.Repositories;
using BackendSRS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendSRS.Application.Services
{
    public class VideosService
    {
        private readonly IVideosRepository _videosRepository;

        public VideosService(IVideosRepository VideosRepository)
        {
            _videosRepository = VideosRepository;
        }

        public List<Videos> GetVideos()
        {
            return _videosRepository.GetVideos();
        }
    }
}
