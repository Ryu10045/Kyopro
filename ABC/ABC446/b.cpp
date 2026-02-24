#include <bits/stdc++.h>
using namespace std;

#define rep(i,s,e) for(int i=s;i < e; i++)
#define vi vector<int>
#define vvi vector<vector<int>>
#define vl vector<int64_t>
#define vvl vector<vector<int64_t>>

int main(){
    int n,m;
    cin >> n >> m;
    vector<bool> selected(m);
    vi ans(n);
    rep(i,0,n){
        int l; cin >> l;
        vi x(l);
        rep(j,0,l) cin >> x[j];
        rep(j,0,l){
            if(!selected[x[j] - 1]){
                ans[i] = x[j];
                selected[x[j] - 1] = true;
                break;
            }
        }
    }

    rep(i,0,n) cout << ans[i] << endl;
}