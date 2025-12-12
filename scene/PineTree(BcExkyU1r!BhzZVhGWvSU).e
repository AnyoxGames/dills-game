13
3878355468289
404948387450219 1761863309043889300
{
  "name": "PineTree",
  "local_enabled": true,
  "local_position": {
    "X": -10.8545160293579102,
    "Y": -11.6724538803100586
  },
  "local_rotation": 0,
  "local_scale": {
    "X": 1,
    "Y": 1
  },
  "previous_sibling": "404946241489444:1761863308543878300",
  "next_sibling": "404950318673357:1761863309493866400",
  "parent": "891721465828975:1761158277601834900",
  "spawn_as_networked_entity": true,
  "linked_prefab": "PineTree.prefab"
},
{
  "cid": 3,
  "aoid": "404948387694803:1761863309043945600",
  "component_type": "Internal_Component",
  "internal_component_type": "Interactable",
  "data": {
    "text": "Harvest Pine Tree",
    "radius": 1,
    "required_hold_time": 0.3000000119209290
  }
},
{
  "cid": 4,
  "aoid": "404948387822599:1761863309043975400",
  "component_type": "Mono_Component",
  "mono_component_type": "PineTree",
  "data": {
    "Interactable": "404948387694803:1761863309043945600",
    "DefaultRenderer": "404948387873941:1761863309043987300",
    "DepletedRenderer": "404948387855064:1761863309043983000"
  }
},
{
  "cid": 5,
  "aoid": "404948387835198:1761863309043978300",
  "component_type": "Internal_Component",
  "internal_component_type": "Polygon_Collider",
  "data": {
    "make_navmesh_loop": true,
    "flip_navmesh_loop": true,
    "points": [
      {
        "X": -0.1877212524414062,
        "Y": -0.2063050270080566
      },
      {
        "X": 0.0189009904861450,
        "Y": -0.2597980499267578
      },
      {
        "X": 0.2158927917480469,
        "Y": -0.1123766899108887
      },
      {
        "X": 0.0703394412994385,
        "Y": 0.1123763322830200
      },
      {
        "X": -0.1783308982849121,
        "Y": 0.0560193061828613
      }
    ]
  }
}
