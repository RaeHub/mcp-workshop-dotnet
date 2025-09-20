using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMonkeyApp;

/// <summary>
/// 원숭이 데이터 관리를 위한 정적 헬퍼 클래스입니다.
/// </summary>
public static class MonkeyHelper
{
    private static List<Monkey>? monkeys;
    private static int randomMonkeyAccessCount = 0;

    /// <summary>
    /// 모든 원숭이 목록을 비동기로 가져옵니다.
    /// </summary>
    public static async Task<List<Monkey>> GetMonkeysAsync()
    {
        if (monkeys == null)
        {
            monkeys = await FetchMonkeysFromServerAsync();
        }
        return monkeys;
    }

    /// <summary>
    /// 이름으로 원숭이 정보를 찾습니다.
    /// </summary>
    public static async Task<Monkey?> GetMonkeyByNameAsync(string name)
    {
        var list = await GetMonkeysAsync();
        return list.FirstOrDefault(m => m.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
    }

    /// <summary>
    /// 랜덤 원숭이를 반환하고, 접근 횟수를 추적합니다.
    /// </summary>
    public static async Task<Monkey?> GetRandomMonkeyAsync()
    {
        var list = await GetMonkeysAsync();
        if (list.Count == 0) return null;
        randomMonkeyAccessCount++;
        var rand = new Random();
        return list[rand.Next(list.Count)];
    }

    /// <summary>
    /// 랜덤 원숭이 접근 횟수를 반환합니다.
    /// </summary>
    public static int GetRandomMonkeyAccessCount() => randomMonkeyAccessCount;

    /// <summary>
    /// MCP 서버에서 원숭이 데이터를 가져옵니다.
    /// 실제 구현에서는 HTTP API 호출 또는 MCP 클라이언트 사용.
    /// </summary>
    private static async Task<List<Monkey>> FetchMonkeysFromServerAsync()
    {
        // TODO: MCP 서버에서 데이터 가져오는 코드로 대체
        await Task.Delay(100); // 비동기 예시
        return new List<Monkey>
        {
            new Monkey { Name = "Baboon", Location = "Africa & Asia", Details = "Baboons are African and Arabian Old World monkeys belonging to the genus Papio.", Image = "https://raw.githubusercontent.com/jamesmontemagno/app-monkeys/master/baboon.jpg", Population = 10000, Latitude = -8.783195, Longitude = 34.508523 },
            new Monkey { Name = "Capuchin Monkey", Location = "Central & South America", Details = "The capuchin monkeys are New World monkeys of the subfamily Cebinae.", Image = "https://raw.githubusercontent.com/jamesmontemagno/app-monkeys/master/capuchin.jpg", Population = 23000, Latitude = 12.769013, Longitude = -85.602364 },
            // ... 나머지 원숭이 데이터 추가 ...
        };
    }
}
