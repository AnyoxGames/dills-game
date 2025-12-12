13
3577707757569
404899532286478 1761863297660585900
{
  "name": "PineTree",
  "local_enabled": true,
  "local_position": {
    "X": -16.0282936096191406,
    "Y": -2.5648970603942871
  },
  "local_rotation": 0,
  "local_scale": {
    "X": 1,
    "Y": 1
  },
  "previous_sibling": "404897457416379:1761863297177138900",
  "next_sibling": "404901534384028:1761863298127076700",
  "parent": "891721465828975:1761158277601834900",
  "spawn_as_networked_entity": true,
  "linked_prefab": "PineTree.prefab"
},
{
  "cid": 3,
  "aoid": "404899532682723:1761863297660677200",
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
  "aoid": "404899532834384:1761863297660712600",
  "component_type": "Mono_Component",
  "mono_component_type": "PineTree",
  "data": {
    "Interactable": "404899532682723:1761863297660677200",
    "DefaultRenderer": "404899532916772:1761863297660731800",
    "DepletedRenderer": "404899532888263:1761863297660725100"
  }
},
{
  "cid": 5,
  "aoid": "404899532856486:1761863297660717700",
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
