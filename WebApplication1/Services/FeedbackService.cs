﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.DTOs;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class FeedbackService : IFeedbackService
    {
        private IDatafeedback data;
        private static int id = 4;

        public FeedbackService(IDatafeedback data)
        {
            this.data = data;
        }
        public void Create(FeedbackDTO feedbackDto)
        {
            Feedback feedback = toEntity(feedbackDto);
            feedback.Id = ++id;
            data.Feedbacks.Add(feedback);
        }

        public void Delete(int id)
        {
            Feedback feedback = this.GetEntityById(id);
            data.Feedbacks.Remove(feedback);
        }

        public List<FeedbackDTO> GetAll()
        {
            return data.Feedbacks
                .Select(x => toDTO(x))
                .ToList();
        }

        public FeedbackDTO GetById(int id)
        {
            return toDTO(GetEntityById(id));
        }

        private Feedback GetEntityById(int id)
        {
            return data.Feedbacks.FirstOrDefault(u => u.Id == id);
        }

        private Feedback toEntity(FeedbackDTO feedbackDTO)
        {
            return new Feedback(feedbackDTO.Id, feedbackDTO.Name, feedbackDTO.Email, feedbackDTO.Message);
        }

        private FeedbackDTO toDTO(Feedback feedback)
        {
            return new FeedbackDTO(feedback.Id, feedback.Name, feedback.Email, feedback.Message);
        }
    }
}

