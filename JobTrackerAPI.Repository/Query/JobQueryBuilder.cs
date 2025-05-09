﻿using JobTrackerAPI.Model.DTOs;
using JobTrackerAPI.Repository.Entities;
using Microsoft.EntityFrameworkCore;

namespace JobTrackerAPI.Repository.Query
{
    public static class JobQueryBuilder
    {
        public static IQueryable<JobEntity> ApplyFilters(IQueryable<JobEntity> query, JobQueryParameters parameters)
        {
            if (!string.IsNullOrWhiteSpace(parameters.Advertiser))
                query = query.Where(j => j.Advertiser.ToLower().Contains(parameters.Advertiser.ToLower()));

            if (!string.IsNullOrWhiteSpace(parameters.Advertisement))
                query = query.Where(j => j.Advertisement.ToLower().Contains(parameters.Advertisement.ToLower()));

            if (!string.IsNullOrWhiteSpace(parameters.Location))
                query = query.Where(j => j.Location != null && parameters.Location.Split('+', StringSplitOptions.RemoveEmptyEntries).Contains(j.Location));

            if (!string.IsNullOrWhiteSpace(parameters.Status))
            {
                var allowedStatuses = parameters.Status.Split(',', StringSplitOptions.RemoveEmptyEntries);
                query = query.Where(j => allowedStatuses.Contains(j.Status));
            }

            if (parameters.StartDate.HasValue)
                query = query.Where(j => j.AppliedAt >= parameters.StartDate.Value);

            if (parameters.EndDate.HasValue)
                query = query.Where(j => j.AppliedAt <= parameters.EndDate.Value);

            return query;
        }

        public static IQueryable<JobEntity> ApplySort(IQueryable<JobEntity> query, JobQueryParameters parameters)
        {
            if (string.IsNullOrWhiteSpace(parameters.Sort))
                return query.OrderByDescending(j => j.AppliedAt);

            var sortMap = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
            {
                ["_id"] = "Id",
                ["advertisement"] = "Advertisement",
                ["advertiser"] = "Advertiser",
                ["advertiserWebsite"] = "AdvertiserWebsite",
                ["location"] = "Location",
                ["advertisementUrl"] = "AdvertisementUrl",
                ["status"] = "Status",
                ["createdAt"] = "CreatedAt",
                ["appliedAt"] = "AppliedAt"
            };

            foreach (var field in parameters.Sort.Split(',', StringSplitOptions.RemoveEmptyEntries).Reverse())
            {
                var isDesc = field.StartsWith("-");
                var rawField = isDesc ? field[1..] : field;

                if (sortMap.TryGetValue(rawField, out var efField))
                {
                    query = isDesc
                        ? query.OrderByDescending(e => EF.Property<object>(e, efField))
                        : query.OrderBy(e => EF.Property<object>(e, efField));
                }
            }

            return query;
        }

    }
}