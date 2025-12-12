13
3513283248129
404883437806588 1761863293910555700
{
  "name": "PineTree",
  "local_enabled": true,
  "local_position": {
    "X": -16.2420902252197266,
    "Y": 2.0530185699462891
  },
  "local_rotation": 0,
  "local_scale": {
    "X": 1,
    "Y": 1
  },
  "previous_sibling": "404879789751561:1761863293060554800",
  "next_sibling": "404885726460111:1761863294443814000",
  "parent": "891721465828975:1761158277601834900",
  "spawn_as_networked_entity": true,
  "linked_prefab": "PineTree.prefab"
},
{
  "cid": 3,
  "aoid": "404883438059084:1761863293910613200",
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
  "aoid": "404883438181935:1761863293910641900",
  "component_type": "Mono_Component",
  "mono_component_type": "PineTree",
  "data": {
    "Interactable": "404883438059084:1761863293910613200",
    "DefaultRenderer": "404883438235900:1761863293910654400",
    "DepletedRenderer": "404883438218442:1761863293910650400"
  }
},
{
  "cid": 5,
  "aoid": "404883438197716:1761863293910645600",
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
