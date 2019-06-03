using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using AutoMapper;
using Exercise.Api.DbModels;
using Exercise.Api.Interfaces;
using Exercise.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exercise.Api.Services
{
    public class DynamoDbExerciseStorage : IExerciseService
    {
        private IMapper _mapper;

        public DynamoDbExerciseStorage(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<string> Add(ExerciseModel model)
        {
            var dbModel = _mapper.Map<ExerciseDbModel>(model);

            dbModel.Id = new Guid().ToString();
            dbModel.CreatedAt = DateTime.UtcNow;
            dbModel.Status = TransactionStatus.Pending;

            using (var client = new AmazonDynamoDBClient())
            {
                using(var context = new DynamoDBContext(client))
                {
                    await context.SaveAsync(dbModel);
                }
            }

            return dbModel.Id;
        }

        public async Task Confirm(ConfirmTransactionModel model)
        {
            using (var client = new AmazonDynamoDBClient())
            {
                using (var context = new DynamoDBContext(client))
                {
                    var record = await context.LoadAsync<ExerciseDbModel>(model.Id);

                    if(record == null)
                    {
                        throw new KeyNotFoundException($"record with id ${model.Id} not found.");
                    }

                    if(model.Status == TransactionStatus.Active)
                    {
                        record.Status = TransactionStatus.Active;

                        await context.SaveAsync(record);
                    }
                    else
                    {
                        await context.DeleteAsync(record);
                    }
                }
            }
        }
    }
}
