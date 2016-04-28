﻿using System.Collections;
using System.Collections.Generic;
using System.Security.Policy;
using System.Web.Http;
using System.Web.Http.Routing;
using AutoMapper;
using DomainModel;
using Web.Util;

namespace Web.Models
{
    public static class ModelFactory
    {
        private static readonly IMapper AnnotationMapper;
        private static readonly IMapper AnswerMapper;
        private static readonly IMapper CommentMapper;
        private static readonly IMapper QuestionMapper;
        private static readonly IMapper SearchMapper;
        private static readonly IMapper SearchUserMapper;
        private static readonly IMapper TagMapper;
        private static readonly IMapper TagListMapper;
        private static readonly IMapper UserMapper;
        
        static ModelFactory()
        {
            var annotationCfg = new MapperConfiguration(cfg => cfg.CreateMap<Annotation, CommentModel>());
            AnnotationMapper = annotationCfg.CreateMapper();

            var answerCfg = new MapperConfiguration(cfg => cfg.CreateMap<Answer, AnswerModel>());
            AnswerMapper = answerCfg.CreateMapper();

            var commentCfg = new MapperConfiguration(cfg => cfg.CreateMap<Comment, CommentModel>());
            CommentMapper = commentCfg.CreateMapper();

            var questionCfg = new MapperConfiguration(cfg => cfg.CreateMap<Question, QuestionModel>());
            QuestionMapper = questionCfg.CreateMapper();

            var searchCfg = new MapperConfiguration(cfg => cfg.CreateMap<Search, SearchModel>());
            SearchMapper = searchCfg.CreateMapper();

            var searchUserCfg = new MapperConfiguration(cfg => cfg.CreateMap<SearchUser, SearchUserModel>());
            SearchUserMapper = searchUserCfg.CreateMapper();

            var tagCfg = new MapperConfiguration(cfg => cfg.CreateMap<Tag, TagModel>());
            TagMapper = tagCfg.CreateMapper();

            var tagListCfg = new MapperConfiguration(cfg => cfg.CreateMap<IList<Tag>, IList<TagModel>>());
            TagListMapper = tagListCfg.CreateMapper();

            var userCfg = new MapperConfiguration(cfg => cfg.CreateMap<User, UserModel>());
            UserMapper = userCfg.CreateMapper();
        }

        public static AnnotationModel Map(Annotation annotation, UrlHelper urlHelper)
        {
            if (annotation == null) return null;

            var annotationModel = AnnotationMapper.Map<AnnotationModel>(annotation);
            annotationModel.Url = urlHelper.Link(Config.AnnotationsRoute, new { annotation.Id });

            return annotationModel;
        }

        public static AnswerModel Map(Answer answer, UrlHelper urlHelper)
        {
            if (answer == null) return null;

            var answerModel = AnswerMapper.Map<AnswerModel>(answer);
            answerModel.Url = urlHelper.Link(Config.AnswersRoute, new { answer.Id });
            
            return answerModel;
        }

        public static CommentModel Map(Comment comment, UrlHelper urlHelper)
        {
            if (comment == null) return null;

            var commentModel = CommentMapper.Map<CommentModel>(comment);
            commentModel.Url = urlHelper.Link(Config.CommentsRoute, new { comment.Id });

            return commentModel;
        }

        public static QuestionModel Map(Question question, UrlHelper urlHelper)
        {
            if (question == null) return null;

            var tagModels = new List<TagModel>();

            var questionModel = QuestionMapper.Map<QuestionModel>(question);
            foreach (var tag in question.Tags)
            {
                var tagModel = TagMapper.Map<TagModel>(tag);
                tagModel.Url = urlHelper.Link(Config.TagsRoute, new { tag.Id });
                tagModels.Add(tagModel);
            }
            questionModel.Url = urlHelper.Link(Config.QuestionsRoute, new {question.Id});
            questionModel.QuestionTags = tagModels;

            return questionModel;
        }

        public static SearchModel Map(Search search, UrlHelper urlHelper)
        {
            if (search == null) return null;

            var searchModel = SearchMapper.Map<SearchModel>(search);
            searchModel.Url = urlHelper.Link(Config.SearchesRoute, new { search.Id });

            return searchModel;
        }

        public static SearchUserModel Map(SearchUser searchUser, UrlHelper urlHelper)
        {
            if (searchUser == null) return null;

            var searchUserModel = SearchUserMapper.Map<SearchUserModel>(searchUser);
            searchUserModel.Url = urlHelper.Link(Config.SearchUsersRoute, new { searchUser.Id });

            return searchUserModel;
        }

        public static TagModel Map(Tag tag, UrlHelper urlHelper)
        {
            if (tag == null) return null;

            var tagModel = TagMapper.Map<TagModel>(tag);
            tagModel.Url = urlHelper.Link(Config.TagsRoute, new { tag.Id });

            return tagModel;
        }

        public static UserModel Map(User user, UrlHelper urlHelper)
        {
            if (user == null) return null;

            var userModel = UserMapper.Map<UserModel>(user);
            userModel.Url = urlHelper.Link(Config.UsersRoute, new { user.Id });

            return userModel;
        }
    }
}