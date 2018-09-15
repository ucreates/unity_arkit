using UnityEngine;
using System;
using System.Collections.Generic;
using Core.Math;
namespace Frontend.Component.Route {
public sealed class ManhattanRouteSearch : BaseRouteSearch {
    private const int DIRECTION_X = 0x01;
    private const int DIRECTION_Y = 0x02;
    private const int DIRECTION_Z = 0x04;
    public ManhattanRouteSearch() {
    }
    public override List<Vector3> Execute() {
        List<Vector3> routeList = new List<Vector3>();
        if (false == this.IsReadyExecute()) {
            return routeList;
        }
        Vector3 distance = this.goal - this.start;
        float x = Mathf.Abs(distance.x);
        float y = Mathf.Abs(distance.y);
        float z = Mathf.Abs(distance.z);
        int tdx = Convert.ToInt32(x);
        int tdy = Convert.ToInt32(y);
        int tdz = Convert.ToInt32(z);
        float dx = 0f <= distance.x ? 1f : -1f;
        float dy = 0f <= distance.y ? 1f : -1f;
        float dz = 0f <= distance.z ? 1f : -1f;
        float nx = this.start.x;
        float ny = this.start.y;
        float nz = this.start.z;
        for (;;) {
            if (0 == tdx && 0 == tdy && 0 == tdz) {
                break;
            }
            int movementDirection = this.GetDirection(tdx, tdy, tdz);
            for (int i = 0; i < 3; i++) {
                if (0x1 == (movementDirection >> i)) {
                    if (0 == i && 0 < tdx) {
                        nx += dx;
                        tdx--;
                    } else if (1 == i && 0 < tdy) {
                        ny += dy;
                        tdy--;
                    } else if (2 == i && 0 < tdz) {
                        nz += dz;
                        tdz--;
                    }
                    break;
                }
            }
            routeList.Add(new Vector3(nx, ny, nz));
        }
        return routeList;
    }
    private int GetDirection(int tdx, int tdy, int tdz) {
        int threshold = UnityEngine.Random.Range(0, 10);
        int ret = 0;
        if (0 <= threshold && threshold < 3) {
            ret |= ManhattanRouteSearch.DIRECTION_X;
        } else if (3 <= threshold && threshold < 6) {
            ret |= ManhattanRouteSearch.DIRECTION_Y;
        } else {
            ret |= ManhattanRouteSearch.DIRECTION_Z;
        }
        if (0 == tdx) {
            ret &= ~ManhattanRouteSearch.DIRECTION_X;
            ret |= false != Condition.ByRandom() ? ManhattanRouteSearch.DIRECTION_Y : ManhattanRouteSearch.DIRECTION_Z;
        }
        if (0 == tdy) {
            ret &= ~ManhattanRouteSearch.DIRECTION_Y;
            ret |= false != Condition.ByRandom() ? ManhattanRouteSearch.DIRECTION_X : ManhattanRouteSearch.DIRECTION_Z;
        }
        if (0 == tdz) {
            ret &= ~ManhattanRouteSearch.DIRECTION_Z;
            ret |= false != Condition.ByRandom() ? ManhattanRouteSearch.DIRECTION_Y : ManhattanRouteSearch.DIRECTION_X;
        }
        return ret;
    }
}
}
