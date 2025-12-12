13
932007903240
908793924011951 1761162255469096500
{
  "name": "PineTree",
  "local_enabled": true,
  "local_position": {
    "X": -12.9639739990234375,
    "Y": -0.9614431858062744
  },
  "local_rotation": 0,
  "local_scale": {
    "X": 1,
    "Y": 1
  },
  "previous_sibling": "908793925455934:1761162255469433000",
  "next_sibling": "908793922426541:1761162255468727100",
  "parent": "891721465828975:1761158277601834900",
  "spawn_as_networked_entity": true,
  "linked_prefab": "PineTree.prefab"
},
{
  "cid": 3,
  "aoid": "908793924203473:1761162255469141100",
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
  "aoid": "908793924215857:1761162255469144000",
  "component_type": "Mono_Component",
  "mono_component_type": "PineTree",
  "data": {
    "Interactable": "908793924203473:1761162255469141100",
    "DefaultRenderer": "908793924254686:1761162255469153000",
    "DepletedRenderer": "908793924264361:1761162255469155300"
  }
},
{
  "cid": 5,
  "aoid": "908793924224672:1761162255469146000",
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
