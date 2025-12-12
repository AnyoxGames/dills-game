13
3191160700929
404833652599364 1761863282310550800
{
  "name": "PineTree",
  "local_enabled": true,
  "local_position": {
    "X": -0.7848987579345703,
    "Y": 9.4502372741699219
  },
  "local_rotation": 0,
  "local_scale": {
    "X": 1,
    "Y": 1
  },
  "previous_sibling": "404830218307183:1761863281510356700",
  "next_sibling": "404836870638822:1761863283060356800",
  "parent": "891721465828975:1761158277601834900",
  "spawn_as_networked_entity": true,
  "linked_prefab": "PineTree.prefab"
},
{
  "cid": 3,
  "aoid": "404833652951276:1761863282310631600",
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
  "aoid": "404833653096057:1761863282310665300",
  "component_type": "Mono_Component",
  "mono_component_type": "PineTree",
  "data": {
    "Interactable": "404833652951276:1761863282310631600",
    "DefaultRenderer": "404833653174661:1761863282310683700",
    "DepletedRenderer": "404833653149205:1761863282310677800"
  }
},
{
  "cid": 5,
  "aoid": "404833653118675:1761863282310670600",
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
