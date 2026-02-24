#include <bits/stdc++.h>
#include <vector>
using namespace std;

#define rep(i,s,e) for(int i=s;i < e; i++)
#define vi vector<int>
#define vvi vector<vector<int>>
#define vl vector<int64_t>
#define vvl vector<vector<int64_t>>

void solve(vi &ans){
    int n,d;
    cin >> n >> d;
    vi a(n),b(n);
    deque<int> m;

    rep(i,0,n) cin >> a[i];
    rep(i,0,n) cin >> b[i];
    rep(i,0,n){
        rep(j,0,a[i]) m.push_back(i);
        rep(j,0,b[i]) if(!m.empty()) m.pop_front();
        while (!m.empty() && m.front() == i - d)
        {
            m.pop_front();
        }
    }
    ans.emplace_back(m.size());
}

int main(){
    int t;
    cin >> t;
    vi ans;
    rep(i,0,t){
        solve(ans);
    }
    rep(i,0,t) cout << ans[i] << endl;
}