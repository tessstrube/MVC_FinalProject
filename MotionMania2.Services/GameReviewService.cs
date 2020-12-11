using MotionMania2.Data;
using MotionMania2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotionMania2.Services
{
    public class GameReviewService
    {
        private readonly Guid _userId;

        public GameReviewService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateGameReview(GameReviewCreate model)
        {
            var entity =
                new GameReview()
                {
                    OwnerId = _userId,
                    GameTitle = model.GameTitle,
                    GameDeveloper = model.GameDeveloper,
                    Platform = model.Platform,
                    GameGenre = model.GameGenre,
                    GameReleaseYear = model.GameReleaseYear,
                    GameMania = model.GameMania,
                    GameRating = model.GameRating
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.GameReviews.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<GameReviewListItem> GetGameReviews()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .GameReviews
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new GameReviewListItem
                                {
                                    GameReviewId = e.GameReviewId,
                                    GameTitle = e.GameTitle,
                                    GameDeveloper = e.GameDeveloper,
                                    Platform = e.Platform,
                                    GameGenre = e.GameGenre,
                                    GameReleaseYear = e.GameReleaseYear,
                                    GameMania = e.GameMania,
                                    GameRating = e.GameRating
                                }
                         );
                return query.ToArray();
            }
        }
        public GameReviewDetail GetGameReviewById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .GameReviews
                        .Single(e => e.GameReviewId == id && e.OwnerId == _userId);
                return
                    new GameReviewDetail
                    {
                        GameReviewId = entity.GameReviewId,
                        GameTitle = entity.GameTitle,
                        GameDeveloper = entity.GameDeveloper,
                        Platform = entity.Platform,
                        GameGenre = entity.GameGenre,
                        GameReleaseYear = entity.GameReleaseYear,
                        GameMania = entity.GameMania,
                        GameRating = entity.GameRating,
                    };
            }
        }
        public bool UpdateGameReview(GameReviewEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .GameReviews
                        .Single(e => e.GameReviewId == model.GameReviewId && e.OwnerId == _userId);

                entity.GameTitle = model.GameTitle;
                entity.GameDeveloper = model.GameDeveloper;
                entity.Platform = model.Platform;
                entity.GameGenre = model.GameGenre;
                entity.GameReleaseYear = model.GameReleaseYear;
                entity.GameMania = model.GameMania;
                entity.GameRating = model.GameRating;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteGameReview(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .GameReviews
                        .Single(e => e.GameReviewId == id && e.OwnerId == _userId);
                ctx.GameReviews.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}