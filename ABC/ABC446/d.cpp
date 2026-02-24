#include <bits/stdc++.h>
using namespace std;

#define rep(i,s,e) for(int i=s;i < e; i++)
#define vi vector<int>
#define vvi vector<vector<int>>
#define vl vector<int64_t>
#define vvl vector<vector<int64_t>>

int l[200009];
int main(){
    int n;
    cin >> n;
    vi a(n);
    rep(i,0,n) cin >> a[i];

    vi dp(n+9); //dp[i] 最後の要素がa[i]であるような部分列のうち、最長のものの長さ
    int len = 0;

    rep(i,1,n+1) {
        int pos = lower_bound(l + 1, l + len + 1, a[i-1]) - l;
        dp[i] = pos;


    }
}