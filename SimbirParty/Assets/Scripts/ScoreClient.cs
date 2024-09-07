using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

public class ScoreClient
{
    private const string _HOST = "https://score.mrexpen.duckdns.org:444";

    /// <summary>
    /// ��������� ������ � �����.
    /// </summary>
    /// <param name="score">���������� � �����.</param>
    /// <returns>����.</returns>
    public async Task<ScoreEntity> SendScoreAsync(ScoreEntity score)
    {
        using (var client = new HttpClient())
        {
            var json = JsonConvert.SerializeObject(score);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync($"{_HOST}/Scores", content);

            return JsonConvert.DeserializeObject<ScoreEntity>(json);
        }
    }

    /// <summary>
    /// �������� ������ ����� ������ �� �������������� ������������.
    /// </summary>
    /// <param name="playerId">������������� ������.</param>
    /// <returns>������ ������ ������������.</returns>
    public async Task<List<ScoreEntity>> GetScoresByPlayerIdAsync(Guid playerId)
    {
        using (var client = new HttpClient())
        {
            var response = await client.GetAsync($"{_HOST}/Players/{playerId}/Scores");
            var json = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<List<ScoreEntity>>(json);
        }
    }

    /// <summary>
    /// �������� ������ ���� ������.
    /// </summary>
    /// <param name="page">����� ��������.</param>
    /// <param name="pageSize">������ ��������.</param>
    /// <returns>������ ������.</returns>
    public async Task<List<ScoreEntity>> GetScoresAsync(int page, int pageSize)
    {
        using (var client = new HttpClient())
        {
            var response = await client.GetAsync($"{_HOST}/Scores?page={page}&pageSize={pageSize}");
            var json = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<List<ScoreEntity>>(json);
        }
    }
    /// <summary>
    /// �������� ���������� �� ����� �� ��� ��������������.
    /// </summary>
    /// <param name="scoreId">������������� �����.</param>
    /// <returns>����.</returns>
    public async Task<ScoreEntity> GetScoresByIdAsync(int scoreId)
    {
        using (var client = new HttpClient())
        {
            var response = await client.GetAsync($"{_HOST}/Scores/{scoreId}");
            var json = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<ScoreEntity>(json);
        }
    }
}