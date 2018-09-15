using UnityEngine;
using System.Collections;
namespace Frontend.Component.Vfx.Sprine {
public class Parabora {
    private const float GRAVITY = 0.98f;
    public float velocity {
        get;
        set;
    }
    public float mass {
        get;
        set;
    }
    public float radian {
        get;
        set;
    }
    public Parabora() {
        this.velocity = 1f;
        this.mass = 1f;
        this.radian = 0f;
    }
    public Vector3 Create(float currentFrame) {
        float sin = Mathf.Sin(this.radian);
        float cos = Mathf.Cos(this.radian);
        float nx = this.velocity * cos * currentFrame;
        float ny = (this.velocity * sin * currentFrame) - (Parabora.GRAVITY * Mathf.Pow(currentFrame, 2f) / 2f);
        return new Vector3(nx, ny, 0f);
    }
}
}
