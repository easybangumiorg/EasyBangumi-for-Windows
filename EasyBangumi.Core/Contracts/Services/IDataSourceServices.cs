﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyBangumi.Core.DataSource.Summary;
using EasyBangumi.Core.Models;

namespace EasyBangumi.Core.Contracts.Services;
public interface IDataSourceServices
{
    // 获取每日更新
    public Task<List<BangumiCoverSummary>> DailyUpdate();

    // 获取周几的更新 1-7
    public Task<List<BangumiCoverSummary>> DailyUpdate(int Week);

    // 获取更新周表
    public Task<List<List<BangumiCoverSummary>>> Calendar();

    // 获取番剧详细信息
    public Task<BangumiSummary> GetInfo(BangumiCoverSummary Cover);

    // 搜索
    public Task<List<BangumiCoverSummary>> Search(string Keyword, int point);

    // 获取当前选择的源信息
    public DataSourceSummary DataSource
    {
        get;
    }

    // 获取所有注册的源的信息
    public List<DataSourceSummary> GetAllDataSource();

    // 选择使用的源
    public bool ChooseDataSource(int target);

    // TODO: 剩下扩展方法
}