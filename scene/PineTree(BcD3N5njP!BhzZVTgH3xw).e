13
3534758084609
404885726460111 1761863294443814000
{
  "name": "PineTree",
  "local_enabled": true,
  "local_position": {
    "X": -16.2634677886962891,
    "Y": 0.7061265110969543
  },
  "local_rotation": 0,
  "local_scale": {
    "X": 1,
    "Y": 1
  },
  "previous_sibling": "404883437806588:1761863293910555700",
  "next_sibling": "404897457416379:1761863297177138900",
  "parent": "891721465828975:1761158277601834900",
  "spawn_as_networked_entity": true,
  "linked_prefab": "PineTree.prefab"
},
{
  "cid": 3,
  "aoid": "404885726711360:1761863294443871600",
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
  "aoid": "404885726832620:1761863294443899800",
  "component_type": "Mono_Component",
  "mono_component_type": "PineTree",
  "data": {
    "Interactable": "404885726711360:1761863294443871600",
    "DefaultRenderer": "404885726882586:1761863294443911600",
    "DepletedRenderer": "404885726866289:1761863294443907700"
  }
},
{
  "cid": 5,
  "aoid": "404885726846208:1761863294443903000",
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
